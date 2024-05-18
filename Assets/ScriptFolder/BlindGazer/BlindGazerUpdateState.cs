using UnityEngine;

public class BlindGazerUpdateState : MonoBehaviour
{
    public float rangeUpAndDown = 3f;

    public void UpdateState(BlindGazerMovement movementScript)
    {
        Vector3 currentPosition = transform.position;

        if (currentPosition.y >= rangeUpAndDown && movementScript != null)
        {
            movementScript.SetDirection(false);
        }
        else if (currentPosition.y <= -rangeUpAndDown && movementScript != null)
        {
            movementScript.SetDirection(true);
        }
    }
}
