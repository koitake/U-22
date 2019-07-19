using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesKnight_WeakPoint : MonoBehaviour
{
    DeathKnight deathKnight;

    Evolution evolution;
    Evolution1 evolution1;

    private GameObject parent;

    //共有のフラグ
    public static bool Sinka_flg = true;
    public static bool Sinka_flg1 = false;
    public static bool Sinka_flg2 = false;

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

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Sword" && Sinka_flg == true)
        {
            Transform wgbar = col.transform.Find("sword1Canvas/WGbar");
            evolution = wgbar.gameObject.GetComponent<Evolution>();
            evolution.Set_wgslider(20);
            evolution.Set_Wg(20);
            deathKnight = parent.gameObject.GetComponent<DeathKnight>();
            deathKnight.Die();
        }
        if (col.gameObject.tag == "Sword" && Sinka_flg1 == true)
        {
            Transform Wgbar1 = col.transform.Find("sword2Canvas/Wgbar1");
            evolution1 = Wgbar1.gameObject.GetComponent<Evolution1>();
            evolution1.Set_wgslider1(20);
            evolution1.Set_Wg1(20);
            deathKnight = parent.gameObject.GetComponent<DeathKnight>();
            deathKnight.Die();
        }
        if (col.gameObject.tag == "Sword" && Sinka_flg2 == true)
        {
            deathKnight = parent.gameObject.GetComponent<DeathKnight>();
            deathKnight.Die();
        }
    }

    public static void Set_Flg()
    {
        Sinka_flg = false;
        Sinka_flg1 = true;
    }

    public static void Set_Flg1()
    {
        Sinka_flg1 = false;
        Sinka_flg2 = true;
    }

    public static bool Get_Flg()
    {
        return Sinka_flg;
    }

    public static bool Get_Flg1()
    {
        return Sinka_flg1;
    }

    public static bool Get_Flg2()
    {
        return Sinka_flg2;
    }
}
