using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AxyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f; // Desired speed
    public InputController inputController;
    public PhysicsController physicsController;
    public StateController stateController;
    public AudioController audioController;
    void Start()
    {
        // Obtener referencias a los controladores
        inputController = GetComponent<InputController>();
        physicsController = GetComponent<PhysicsController>();
        stateController = GetComponent<StateController>();
        audioController = GetComponent<AudioController>();
    }

    // Update is called once per frame
    void Update()
    {
        inputController.updateMovements(speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EditorApplication.Beep();
    }
}
