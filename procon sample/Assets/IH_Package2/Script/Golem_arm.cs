using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem_arm : MonoBehaviour
{
    Golem_Script golem_script;
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
            golem_script = parent.gameObject.GetComponent<Golem_Script>();
            golem_script.flg = true;
        }
    }
}
