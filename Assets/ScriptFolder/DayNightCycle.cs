using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float dayDuration = 60.0f; 
    public float nightDuration = 60.0f; 
    public Color dayColor;
    public Color nightColor;

    private float timer = 0.0f;
    private bool isDay = true;
    private SpriteRenderer backgroundRenderer;

    void Start()
    {
        backgroundRenderer = GetComponent<SpriteRenderer>();
        if (backgroundRenderer == null)
        {
            Debug.LogError("Background SpriteRenderer is missing!");
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (isDay && timer > dayDuration)
        {
            isDay = false;
            timer = 0.0f;
            backgroundRenderer.color = dayColor;
            Debug.LogError("Its daytime");
        }
        else if (!isDay && timer > nightDuration)
        {
            isDay = true;
            timer = 0.0f;
            backgroundRenderer.color = nightColor;
            Debug.LogError("Its nighttime");
        }
    }

    public bool IsNight()
    {
        return !isDay;
    }
}
