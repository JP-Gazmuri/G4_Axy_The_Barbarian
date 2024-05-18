using UnityEngine;

public class BlindGazer : MonoBehaviour
{
    private BlindGazerMovement movementScript;
    private BlindGazerUpdateState updateStateScript;

    void Start()
    {
        movementScript = GetComponent<BlindGazerMovement>();
        if (movementScript == null)
        {
            Debug.LogError("BlindGazerMovement script is missing!");
        }

        updateStateScript = GetComponent<BlindGazerUpdateState>();
        if (updateStateScript == null)
        {
            Debug.LogError("BlindGazerUpdateState script is missing!");
        }
    }

    void Update()
    {
        // Update state
        if (updateStateScript != null)
        {
            updateStateScript.UpdateState(movementScript);
        }
    }
}
