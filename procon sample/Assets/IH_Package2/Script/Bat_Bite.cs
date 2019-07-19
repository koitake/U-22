using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_Bite : MonoBehaviour
{
    Bat_Script bat_script;
    private GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        //親オブジェクトの取得
        parent = transform.root.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sword")
        {
            bat_script = parent.gameObject.GetComponent<Bat_Script>();
            bat_script.flg = true;
        }
    }
}
