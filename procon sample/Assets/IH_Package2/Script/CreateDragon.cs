using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDragon : MonoBehaviour
{
    public GameObject Dragon;
    private bool create_flg = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float gameTime = TimeManager.get_time();

        //n秒たったらドラゴンを生成する
        if (gameTime < 400 && create_flg == true)
        {
            create_flg = false;
            GameObject go = Instantiate(Dragon) as GameObject;
        }
    }
}
