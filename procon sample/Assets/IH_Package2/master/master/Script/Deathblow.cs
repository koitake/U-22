using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deathblow : MonoBehaviour
{
    Slider deathblow;
    public static float db = 0f;
    public Image sliderImage;

    public GameObject viveTest;

    public bool deathbloe;
    // Start is called before the first frame update
    void Start()
    {
        deathblow = GetComponent<Slider>();//sliderコンポーネントの取得
        
        deathblow.value = db;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            db += 10f;
            deathblow.value = db;
        }
        if (deathblow.value >= 150)
        {
            deathbloe = true;
        }

        //----------------------------------------------
        if (viveTest.GetComponent<ViveTest>().grab == true && viveTest.GetComponent<ViveTest>().wg == true)
        {
            db = 0;
        }
        
    }
    public static float getA()
    {
        return db;
    }
   

    public void Method()
    {
        if (deathblow.value >= 150)
        {
            sliderImage.color = new Color32(255, 0, 255, 255);
        }
        if (deathblow.value <= 149)
        {
            sliderImage.color = new Color32(255, 255, 0, 255);
        }


    }
    public void Set_deathblow(float num)
    {
        deathblow.value += num;
    }

    public float Get_slider()
    {
        return deathblow.value;
    }

    public void Set_Db(float db_num)
    {
        db += db_num;
    }

    public float Get_Db()
    {
        return db;
    }
}
