using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    public void Move(Vector2 movement)
    {
        transform.Translate(movement);
    }
}
