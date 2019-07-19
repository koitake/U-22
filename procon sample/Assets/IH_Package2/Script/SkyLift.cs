using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyLift : MonoBehaviour
{
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 50)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
    }
}
