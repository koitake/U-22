using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TimeManager : MonoBehaviour
{
    public HPbar hpbar;
    public static float totalTime = 500;                // トータル制限時間(シーン間で共有)
    TextMeshPro uiText;  // UIText コンポーネント
    private float hpjudge;
    public bool start_Flg;

    void Start()
    {
        
        // Textコンポーネント取得
        uiText = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        hpjudge = hpbar.Gethpcount();
        //とりあえず-20より時間は下がらない
        if (totalTime <= -20.0f)
        {
            return;
        }

        if(start_Flg == true)
        {
            totalTime -= Time.deltaTime;
        }

        uiText.text = totalTime.ToString("F2");

        if (hpjudge <= 0f) 
        {
            Time.timeScale = 0f;
        }
    }

    public static float get_time()
    {
        return totalTime;
    }
}
