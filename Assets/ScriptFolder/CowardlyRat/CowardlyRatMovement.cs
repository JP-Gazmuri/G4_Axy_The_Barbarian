using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class CowardlyRatMovement : MonoBehaviour
{
  
    public float speed = 4.0f;
    public Vector3 directionMovement = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        transform.position += directionMovement * speed * Time.deltaTime;
    }

    public void setDirection(Vector3 newDirection)
    {
        directionMovement = newDirection;
    }


}
