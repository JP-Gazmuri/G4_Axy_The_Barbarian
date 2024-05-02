using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class BlindGazerScript : MonoBehaviour
{
    public float speed = 5f;
    public float rangeUpAndDown = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        UpdateState();
    }

    void UpdateState()
    {
        Vector3 currentPosition = transform.position;

        if(Mathf.Abs(currentPosition.y) >= rangeUpAndDown)
        {
            speed = -speed;
        }

        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
