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
            Vector3 shootPosition = transform.position; // You can adjust this position if needed
            shootScript.Shoot(shootPosition);
            timingScript.UpdateLastShootTime();
        }
    }
}
