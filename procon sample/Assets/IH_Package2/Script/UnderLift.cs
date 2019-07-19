using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnderLift : MonoBehaviour
{
    public float speed = 3;
    private bool liftDown_flg = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //時間を取得 
        float gameTime = TimeManagerUnder.get_nextime();

        //地下につくまで下がり続ける(一回だけ)
        if (transform.position.y > -50 && liftDown_flg == true)
        {
            transform.position -= transform.up * speed * 2.5f * Time.deltaTime;
        }

        if(gameTime < 300)
        {
            liftDown_flg = false;
            transform.position += transform.up * speed * Time.deltaTime;

            if(transform.position.y > -4)
            {
                SceneManager.LoadScene("Sky");
            }
        }
    }
}
