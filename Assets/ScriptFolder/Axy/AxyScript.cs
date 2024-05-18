using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxyScript : MonoBehaviour
{
    public float speed = 5f; // Desired speed
    public InputController inputController;
    public PhysicsController physicsController;
    public StateController stateController;
    public AudioController audioController;

    void Start()
    {
        // Get references to the controllers or add them if they don't exist
        inputController = gameObject.AddComponent<InputController>();
        physicsController = gameObject.AddComponent<PhysicsController>();
        stateController = gameObject.AddComponent<StateController>();
        audioController = gameObject.AddComponent<AudioController>();
    }

    void Update()
    {
        Vector2 movement = inputController.ProcessInput(speed);
        physicsController.Move(movement);     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioController.PlayCollisionSound();
    }
}
