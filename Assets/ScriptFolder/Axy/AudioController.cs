using UnityEngine;
using UnityEditor;

public class AudioController : MonoBehaviour
{
    public void PlayCollisionSound()
    {
        this.Play();
    }
    
    public void Play()
    {
        EditorApplication.Beep();
    }
}