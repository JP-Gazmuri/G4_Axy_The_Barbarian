using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BlindGazer : MonoBehaviour
{
    private BlindGazerMovement movementScript;
    private BlindGazerUpdateState updateStateScript;
    public WinController Lose;

    void Start()
    {
        Lose = GetComponent<WinController>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el objeto que colisiona es el jugador
        if (collision.gameObject.tag == "Player")
        {
            // Llama al m�todo que maneja la victoria
            Lose.Loser();
        }
    }
}
