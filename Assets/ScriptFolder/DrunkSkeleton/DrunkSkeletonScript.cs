using UnityEngine;

public class DrunkSkeleton : MonoBehaviour
{
    private DrunkSkeletonTiming timingScript;
    private DrunkSkeletonShoot shootScript;

    void Start()
    {
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
            Vector3 shootPosition = transform.position;
            shootScript.Shoot(shootPosition);
            timingScript.UpdateLastShootTime();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GlobalListener.Instance.TriggerLose(); // Notificar al GlobalListener
        }
    }
}
