using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkSkeletonScript : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab of the projectile
    public float shootInterval = 2f; // Interval between shots
    public float projectileLifetime = 3f; // Lifetime of the projectile
    public float shootingOffset = 1.5f; // Offset for shooting relative to the other enemy's movement

    private float lastShootTime;

    void Start()
    {
        lastShootTime = Time.time; // Initialize the last shoot time at the start
    }

    void Update()
    {
        if (Time.time - lastShootTime > shootInterval)
        {
            Shoot(); // Shoot a projectile
        }
    }

    void Shoot()
    {
        Vector2 randomOffset = Random.insideUnitCircle.normalized * 3f;
        GameObject projectile = Instantiate(projectilePrefab, (Vector2)transform.position + randomOffset, Quaternion.identity);
        Destroy(projectile, projectileLifetime);

        lastShootTime = Time.time; // Update the last shoot time
    }
}
