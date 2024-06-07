using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowardlyRatScript : MonoBehaviour
{
    private CowardlyRatMovement movementScript;
    private RatAIScript updateStateScript;
    // Start is called before the first frame update
    void Start()
    {
        movementScript = GetComponent<CowardlyRatMovement>();
        if (movementScript == null)
        {
            Debug.LogError("BlindGazerMovement script is missing!");
        }

        updateStateScript = GetComponent<RatAIScript>();
        if (updateStateScript == null)
        {
            Debug.LogError("BlindGazerUpdateState script is missing!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (updateStateScript != null)
        {
            updateStateScript.updateState(movementScript);
        }
    }
}
