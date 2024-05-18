using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindGazerScript : MonoBehaviour
{
    public float speed = 5f;
    public float rangeUpAndDown = 3f;
    private bool goingUp = true;

    void Update()
    {
        UpdateState();
    }

    void UpdateState()
    {
        Vector3 currentPosition = transform.position;

        if (currentPosition.y >= rangeUpAndDown && goingUp)
        {
            goingUp = false;
        }
        else if (currentPosition.y <= -rangeUpAndDown && !goingUp)
        {
            goingUp = true;
        }

        if (goingUp)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }
}
