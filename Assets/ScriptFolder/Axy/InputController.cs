using UnityEngine;
using System;

public class InputController : MonoBehaviour
{
    public Vector2 ProcessInput(float speed)
    {   
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized * speed * Time.deltaTime;
        return movement;
    }
}
