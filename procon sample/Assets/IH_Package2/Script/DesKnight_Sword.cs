using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesKnight_Sword : MonoBehaviour
{
    DeathKnight deathKnight;
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
            deathKnight = parent.gameObject.GetComponent<DeathKnight>();
            deathKnight.flg = true;
        }
    }
}
