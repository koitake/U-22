using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderGameManager : MonoBehaviour
{
    public GameObject Lift;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Lift.transform.position.y <= -50)
        {
            GameObject.Find("UnderGenerator").GetComponent<underground>().enabled = true;
        }
        else
        {
            GameObject.Find("UnderGenerator").GetComponent<underground>().enabled = false;
        }
    }
}
