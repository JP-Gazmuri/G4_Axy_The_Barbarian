using UnityEngine;
using System.Reflection;

public class DrunkSkeleton : MonoBehaviour
{
    private DrunkSkeletonTiming timingScript;
    private DrunkSkeletonShoot shootScript;
    public WinController Lose;

    void Start()
    {
        Lose = GetComponent<WinController>();
        timingScript = GetComponent<DrunkSkeletonTiming>();
        if (timingScript == null)
        {
            Debug.LogError("DrunkSkeletonTiming script is missing!");
            return;
        }

        shootScript = GetComponent<DrunkSkeletonShoot>();
        if (shootScript == null)
        {
            Debug.LogError("DrunkSkeletonShoot script is missing!");
            return;
        }
    }

    void Update()
    {
        if (timingScript != null && timingScript.ShouldShoot())
        {
            Vector3 shootPosition = transform.position; // You can adjust this position if needed
            shootScript.Shoot(shootPosition);
            timingScript.UpdateLastShootTime();
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
