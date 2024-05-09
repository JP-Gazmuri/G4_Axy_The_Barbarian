using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AxyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f; // Desired speed
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 MovementVector = ProcessInput();
        UpdateState(MovementVector);
    }

    Vector2 ProcessInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized * speed * Time.deltaTime;

        return movement;
    }

    void UpdateState(Vector2 movVector)
    {
        transform.Translate(movVector);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EditorApplication.Beep();
    }
}
