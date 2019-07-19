using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakYUKA : MonoBehaviour
{
    public GameObject Lift;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            Lift.GetComponent<Lift>().Set_Flg();
            //Destroy(this.gameObject);
        }
    }
}
