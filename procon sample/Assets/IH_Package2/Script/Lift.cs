using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lift : MonoBehaviour
{
    public float speed = 3;
    private bool lift_flg;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lift_flg == true)
        {
            transform.position -= transform.up * speed * 2.5f * Time.deltaTime;

            if (transform.position.y < -25)
            {
                SceneManager.LoadScene("UnderGround");
            }
        }
    }

    public void Set_Flg()
    {
        lift_flg = true;
    }
}
