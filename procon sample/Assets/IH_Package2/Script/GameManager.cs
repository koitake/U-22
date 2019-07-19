using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Lift;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Lift.transform.position.y != 0)
        {
            GameObject.Find("EnemyGenerator").GetComponent<EnemyGene>().enabled = false;
        }

        //if (Lift.transform.position.y > 10 && dragon_flg == false)
        //{
        //    dragon_flg = true;

        //    Instantiate(Dragon);
        //}
    }
}
