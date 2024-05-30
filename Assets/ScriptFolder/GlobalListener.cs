using System;
using UnityEngine;

public class GlobalListener : MonoBehaviour
{
    public static GlobalListener Instance { get; private set; }

    public event Action OnWin;
    public event Action OnLose;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make the listener persist across scenes
        }
    }

    public void TriggerWin()
    {
        OnWin?.Invoke();
    }

    public void TriggerLose()
    {
        OnLose?.Invoke();
    }
}
