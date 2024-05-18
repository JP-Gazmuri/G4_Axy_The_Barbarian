using UnityEngine;

public class DrunkSkeletonTiming : MonoBehaviour
{
    public float shootInterval = 2f; // Interval between shots

    private float lastShootTime;

    void Start()
    {
        lastShootTime = Time.time; // Initialize the last shoot time at the start
    }

    public bool ShouldShoot()
    {
        return Time.time - lastShootTime > shootInterval;
    }

    public void UpdateLastShootTime()
    {
        lastShootTime = Time.time; // Update the last shoot time
    }
}
