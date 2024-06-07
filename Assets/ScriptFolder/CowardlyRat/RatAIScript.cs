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
    }
    public void updateState(CowardlyRatMovement movementScript)
    {
        if (player == null)
        {
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            Vector3 directionToAdvance = transform.position - player.position;
            directionToAdvance.Normalize();

            movementScript.setDirection(directionToAdvance);
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > newDirectionInterval)
            {
                timer = 0.0f;
                Vector3 newDirection = PickRandomDirection();
                movementScript.setDirection(newDirection);
            }
        }
    }

    Vector3 PickRandomDirection()
    {
        float randomAngle = Random.Range(0, 360);
        float randomRadian = randomAngle * Mathf.Deg2Rad;
        Vector3 randomDirection = new Vector3(Mathf.Cos(randomRadian), Mathf.Sin(randomRadian), 0);
        randomDirection.Normalize();
        return randomDirection;
    }
}
