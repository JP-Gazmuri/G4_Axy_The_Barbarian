using UnityEngine;

public class DrunkSkeletonShoot : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab of the projectile
    public float projectileLifetime = 3f; // Lifetime of the projectile
    public float shootingOffset = 1.5f; // Offset for shooting relative to the other enemy's movement

    public void Shoot(Vector3 position)
    {
        Vector2 randomOffset = Random.insideUnitCircle.normalized * 3f;
        GameObject projectile = Instantiate(projectilePrefab, (Vector2) transform.position + randomOffset, Quaternion.identity);
        Destroy(projectile, projectileLifetime);
    }
}
