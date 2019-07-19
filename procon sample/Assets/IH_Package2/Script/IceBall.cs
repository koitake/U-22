using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBall : MonoBehaviour
{
    private int waitTime = 8;
    private float tmpTime = 0;
    private float speed = 20;

    Vector3 playerPos = new Vector3(0, 50, 0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tmpTime += Time.deltaTime;

        if(tmpTime > waitTime)
        {
            float stop = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, playerPos, stop);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Sword")
        {
            Destroy(this);
        }
        else
        {
            Destroy(gameObject, 1.0f);
        }
    }
}
