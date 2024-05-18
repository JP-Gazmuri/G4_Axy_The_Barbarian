using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class DrunkSkeletonScript : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public float shootInterval = 2f; // Intervalo entre disparos
    public float projectileLifetime = 3f; // Tiempo de vida del proyectil
    public float shootingOffset = 1.5f; // Desfase de disparo en relaci�n con el movimiento del otro enemigo

    public WinController Lose;
    private float lastShootTime;

    void Start()
    {
        lastShootTime = Time.time; // Inicializa el tiempo del �ltimo disparo al inicio
        Lose = GetComponent<WinController>();
    }

    void Update()
    {
        // Verifica si es tiempo de disparar
        if (Time.time - lastShootTime > shootInterval)
        {
            Shoot(); // Dispara un proyectil
        }
    }

    void Shoot()
    {
        // Genera una posici�n aleatoria dentro de un radio de 3 unidades
        Vector2 randomOffset = Random.insideUnitCircle.normalized * 3f;

        // Instancia el proyectil en una posici�n aleatoria
        GameObject projectile = Instantiate(projectilePrefab, (Vector2)transform.position + randomOffset, Quaternion.identity);

        // Destruye el proyectil despu�s de un tiempo
        Destroy(projectile, projectileLifetime);

        lastShootTime = Time.time; // Actualiza el tiempo del �ltimo disparo
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
