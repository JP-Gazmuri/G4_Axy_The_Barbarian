using UnityEngine;

public class InputController : MonoBehaviour
{
    private Vector2 ProcessInput(float speed)
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
    public void updateMovements(float speed)
    {
        Vector2 MovementVector = ProcessInput(speed);
        UpdateState(MovementVector);
    }
}

public class PhysicsController : MonoBehaviour
{
    // Aqu� implementar�as la l�gica para manejar la f�sica del jugador
}

public class StateController : MonoBehaviour
{
    // Aqu� implementar�as la l�gica para manejar los estados del jugador
}

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Aqu� implementar�as la l�gica para manejar el audio del jugador
}
