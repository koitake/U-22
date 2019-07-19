using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyGameManager : MonoBehaviour
{
    public GameObject Lift;
    public GameObject Dragon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Lift.transform.position.y >= 50)
        {
            Dragon.GetComponent<Dragon>().enabled = true;
        }
    }
}
