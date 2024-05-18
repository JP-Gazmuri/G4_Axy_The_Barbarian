using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
    // Método que se llama cuando otro objeto entra en el trigger
    public GameObject Skeleton;
    public GameObject Blind;
    public GameObject WinImage;
    public WinController winner;

    void Start()
    {
        // Obtener referencias a los controladores
        winner = GetComponent<WinController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el objeto que colisiona es el jugador
        if (collision.gameObject.tag == "Player")
        {
            // Llama al método que maneja la victoria
            winner.WinGame(Skeleton, Blind, WinImage);
        }
    }

}
