using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject Skeleton;
    public GameObject Blind;
    public GameObject WinImage;

    private void Start()
    {
        // Nada que hacer aquí ahora
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Skeleton != null)
            {
                Skeleton.SetActive(false);
            }
            if (Blind != null)
            {
                Blind.SetActive(false);
            }
            if (WinImage != null)
            {
                WinImage.SetActive(true);
            }

            GlobalListener.Instance.TriggerWin(); // Notificar al GlobalListener
        }
    }
}
