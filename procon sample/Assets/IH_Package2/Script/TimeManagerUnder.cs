using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TimeManagerUnder : MonoBehaviour
{
    TextMeshPro uiText;                                        // UIText コンポーネント
    public static float nextTime = 0;                   //次のシーンに引き継ぐ時間  

    void Start()
    {
        nextTime = TimeManager.get_time();

        // Textコンポーネント取得
        uiText = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        //とりあえず-20より時間は下がらない
        if (nextTime <= -20.0f)
        {
            return;
        }

        nextTime -= Time.deltaTime;

        uiText.text = nextTime.ToString("F2");
    }

    public static float get_nextime()
    {
        return nextTime;
    }
}
