using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinController : MonoBehaviour
{
    public void WinGame(GameObject Skeleton, GameObject Blind, GameObject WinImage)
    {
        Debug.Log("¡Has ganado!");
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
    }
    public void Loser()
    {
        SceneManager.LoadScene(0);
    }
}
