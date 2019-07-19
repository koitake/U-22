using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Exploder;

public class SkeletonWeak : MonoBehaviour
{
    Skeleton skeleton;

    Evolution evolution;
    Evolution1 evolution1;

    private GameObject parent;

    bool Sinka_flg = true;
    bool Sinka_flg1 = false;
    bool Sinka_flg2 = false;

    // Start is called before the first frame update
    void Start()
    {
        //親オブジェクトの取得
        parent = transform.root.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Sinka_flg = DesKnight_WeakPoint.Get_Flg();
        Sinka_flg1 = DesKnight_WeakPoint.Get_Flg1();
        Sinka_flg2 = DesKnight_WeakPoint.Get_Flg2();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Sword" && Sinka_flg == true)
        {
            Transform wgbar = col.transform.Find("sword1Canvas/WGbar");
            evolution = wgbar.gameObject.GetComponent<Evolution>();
            evolution.Set_wgslider(20);
            evolution.Set_Wg(20);
            skeleton = parent.gameObject.GetComponent<Skeleton>();
            skeleton.Die();
        }
        if (col.gameObject.tag == "Sword" && Sinka_flg1 == true)
        {
            Transform Wgbar1 = col.transform.Find("sword2Canvas/Wgbar1");
            evolution1 = Wgbar1.gameObject.GetComponent<Evolution1>();
            evolution1.Set_wgslider1(20);
            evolution1.Set_Wg1(20);
            skeleton = parent.gameObject.GetComponent<Skeleton>();
            skeleton.Die();
        }
        if (col.gameObject.tag == "Sword" && Sinka_flg2 == true)
        {
            skeleton = parent.gameObject.GetComponent<Skeleton>();
            skeleton.Die();
        }
    }
}
