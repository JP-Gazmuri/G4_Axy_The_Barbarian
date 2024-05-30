using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinController : MonoBehaviour
{

    private void Start()
    {
        GlobalListener.Instance.OnWin += HandleWin;
        GlobalListener.Instance.OnLose += HandleLose;
    }

    private void OnDestroy()
    {
        if (GlobalListener.Instance != null)
        {
            GlobalListener.Instance.OnWin -= HandleWin;
            GlobalListener.Instance.OnLose -= HandleLose;
        }
    }

    private void HandleWin()
    {
        // Lógica cuando se gana
        Debug.Log("¡Has ganado!");
    }

    private void HandleLose()
    {
        // Lógica cuando se pierde
        SceneManager.LoadScene(0);
    }
}
