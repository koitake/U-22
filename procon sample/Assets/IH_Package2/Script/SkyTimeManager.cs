using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkyTimeManager : MonoBehaviour
{
    TextMeshPro uiText;                                        // UIText コンポーネント
    float totalTime;

    // Start is called before the first frame update
    void Start()
    {
        totalTime = TimeManagerUnder.get_nextime();

        // Textコンポーネント取得
        uiText = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        //とりあえず-20より時間は下がらない
        if (totalTime <= -20.0f)
        {
            return;
        }

        totalTime -= Time.deltaTime;

        uiText.text = totalTime.ToString("F2");
    }
}
