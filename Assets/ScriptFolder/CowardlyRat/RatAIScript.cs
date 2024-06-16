using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAIScript : MonoBehaviour
{
    public bool isRunningAway = false;
    public float newDirectionInterval = 1.0f;
    public float detectionRange = 5.0f;
    public float obstacleDetectionRange = 1.0f;
    public float attackRange = 6.0f;
    public LayerMask obstacleLayerMask;
    public DayNightCycle dayNightCycle;

    private float timer = 1.0f;
    private Transform player;

    private DecisionNode rootNode;

    private void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player not found!");
        }

        if (dayNightCycle == null)
        {
            dayNightCycle = FindObjectOfType<DayNightCycle>();
            if (dayNightCycle == null)
            {
                Debug.LogError("DayNightCycle script is missing!");
            }
        }

        rootNode = new IsPlayerInRangeNode(detectionRange, player,
            new IsNightNode(dayNightCycle, new IsPlayerInRangeNode(attackRange, player, new AttackNode(player), new RunAwayNode(player)), new RunAwayNode(player)),
            new WanderNode(newDirectionInterval));
    }

    public void UpdateState(CowardlyRatMovement movementScript)
    {
        if (player == null)
        {
            Debug.LogError("Player reference is null in UpdateState.");
            return;
        }

        rootNode.Execute(movementScript);
    }

    public abstract class DecisionNode
    {
        public abstract void Execute(CowardlyRatMovement movementScript);
    }

    public class IsPlayerInRangeNode : DecisionNode
    {
        private float detectionRange;
        private Transform player;
        private DecisionNode trueNode;
        private DecisionNode falseNode;

        public IsPlayerInRangeNode(float detectionRange, Transform player, DecisionNode trueNode, DecisionNode falseNode)
        {
            this.detectionRange = detectionRange;
            this.player = player;
            this.trueNode = trueNode;
            this.falseNode = falseNode;
        }

        public override void Execute(CowardlyRatMovement movementScript)
        {
            float distanceToPlayer = Vector3.Distance(movementScript.transform.position, player.position);
            if (distanceToPlayer <= detectionRange)
            {
                trueNode.Execute(movementScript);
            }
            else
            {
                falseNode.Execute(movementScript);
            }
        }
    }

    public class IsNightNode : DecisionNode
    {
        private DayNightCycle dayNightCycle;
        private DecisionNode trueNode;
        private DecisionNode falseNode;

        public IsNightNode(DayNightCycle dayNightCycle, DecisionNode trueNode, DecisionNode falseNode)
        {
            this.dayNightCycle = dayNightCycle;
            this.trueNode = trueNode;
            this.falseNode = falseNode;
        }

        public override void Execute(CowardlyRatMovement movementScript)
        {
            if (dayNightCycle.IsNight())
            {
                trueNode.Execute(movementScript);
            }
            else
            {
                falseNode.Execute(movementScript);
            }
        }
    }

    public class AvoidObstacleNode : DecisionNode
    {
        private float obstacleDetectionRange;
        private LayerMask obstacleLayerMask;
        private DecisionNode trueNode;
        private DecisionNode falseNode;

        public AvoidObstacleNode(float obstacleDetectionRange, LayerMask obstacleLayerMask, DecisionNode trueNode, DecisionNode falseNode)
        {
            this.obstacleDetectionRange = obstacleDetectionRange;
            this.obstacleLayerMask = obstacleLayerMask;
            this.trueNode = trueNode;
            this.falseNode = falseNode;
        }

        public override void Execute(CowardlyRatMovement movementScript)
        {
            Vector3 currentDirection = movementScript.directionMovement;
            RaycastHit2D hit = Physics2D.Raycast(movementScript.transform.position, currentDirection, obstacleDetectionRange, obstacleLayerMask);

            if (hit.collider != null)
            {
                Vector3 newDirection = PickRandomDirection();
                movementScript.setDirection(newDirection);
                trueNode.Execute(movementScript);
            }
            else
            {
                falseNode.Execute(movementScript);
            }
        }

        private Vector3 PickRandomDirection()
        {
            float randomAngle = Random.Range(0, 360);
            float randomRadian = randomAngle * Mathf.Deg2Rad;
            Vector3 randomDirection = new Vector3(Mathf.Cos(randomRadian), Mathf.Sin(randomRadian), 0);
            randomDirection.Normalize();
            return randomDirection;
        }
    }

    public class RunAwayNode : DecisionNode
    {
        private Transform player;

        public RunAwayNode(Transform player)
        {
            this.player = player;
        }

        public override void Execute(CowardlyRatMovement movementScript)
        {
            Vector3 directionToAdvance = movementScript.transform.position - player.position;
            directionToAdvance.Normalize();
            movementScript.setDirection(directionToAdvance);
        }
    }

    public class WanderNode : DecisionNode
    {
        private float newDirectionInterval;
        private float timer = 0.0f;

        public WanderNode(float newDirectionInterval)
        {
            this.newDirectionInterval = newDirectionInterval;
        }

        public override void Execute(CowardlyRatMovement movementScript)
        {
            timer += Time.deltaTime;
            if (timer > newDirectionInterval)
            {
                timer = 0.0f;
                Vector3 newDirection = PickRandomDirection();
                movementScript.setDirection(newDirection);
            }
        }

        private Vector3 PickRandomDirection()
        {
            float randomAngle = Random.Range(0, 360);
            float randomRadian = randomAngle * Mathf.Deg2Rad;
            Vector3 randomDirection = new Vector3(Mathf.Cos(randomRadian), Mathf.Sin(randomRadian), 0);
            randomDirection.Normalize();
            return randomDirection;
        }
    }

    public class AttackNode : DecisionNode
    {
        private Transform player;

        public AttackNode(Transform player)
        {
            this.player = player;
        }

        public override void Execute(CowardlyRatMovement movementScript)
        {
            Debug.Log("Attacking the player!");
        }
    }
}
