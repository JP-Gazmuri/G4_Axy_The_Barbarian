using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAIScript : MonoBehaviour
{
    public bool isRunningAway = false;
    public float newDirectionInterval = 1.0f;
    public float detectionRange = 5.0f;

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

        rootNode = new IsPlayerInRangeNode(detectionRange, player,
            new RunAwayNode(player),
            new WanderNode(newDirectionInterval));
    }

    public void updateState(CowardlyRatMovement movementScript)
    {
        if (player == null)
        {
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
}
