using UnityEngine;

public class BlindGazerMovement : MonoBehaviour
{
    public float speed = 5f;
    private bool goingUp = true;

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (goingUp)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }

    public void SetDirection(bool isGoingUp)
    {
        goingUp = isGoingUp;
    }
}
