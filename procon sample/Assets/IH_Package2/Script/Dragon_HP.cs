using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dragon_HP : MonoBehaviour
{
    Slider dragon_HP_slider;
    Image sliderImage;

    //オブジェクト参照
    public GameObject Slider;       //胸についてるスライダー
    private GameObject Parent;      //Animatorが入ってる本体

    private GameObject HPbarPrefab;

    // Start is called before the first frame update
    void Start()
    {
        dragon_HP_slider = Slider.GetComponent<Slider>();

        //親オブジェクトの取得
        Parent = transform.root.gameObject;

        //スライダーの最大値を設定
        dragon_HP_slider.maxValue = Parent.gameObject.GetComponent<Dragon>().dragonHP;

        HPbarPrefab = GameObject.Find("Lift/Camera/Canvas(1)/HPbar");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Parent.gameObject.GetComponent<Dragon>().dragonHP -= 5;
            dragon_HP_slider.value = Parent.gameObject.GetComponent<Dragon>().dragonHP;
        }

        //体力が0になったら本体のDie関数を呼ぶ
        if(Parent.gameObject.GetComponent<Dragon>().dragonHP <= 0)
        {
            FindObjectOfType<Scoresky>().AddPoint(1500);
            HPbarPrefab.gameObject.GetComponent<HPbar>().Set_WinPanel();
            Parent.gameObject.GetComponent<Dragon>().Die();

            Parent.gameObject.GetComponent<Dragon>().enabled = false;

        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Sword")
        {
            //ダメージ処理
            float damagePoint = Sword_Player.Get_SwordPower();

            Parent.gameObject.GetComponent<Dragon>().dragonHP -= damagePoint;

            dragon_HP_slider.value = Parent.gameObject.GetComponent<Dragon>().dragonHP;

            if (Parent.gameObject.GetComponent<Dragon>().magicAttack_flg == true)
            {
                Parent.gameObject.GetComponent<Dragon>().magicAttackCancel -= damagePoint;

                if(Parent.gameObject.GetComponent<Dragon>().magicAttackCancel <= 0)
                {
                    //キャンセルダメージを受けたアニメーションを再生
                    Parent.gameObject.GetComponent<Dragon>().CancelTakeDamage();
                }
            }
            else
            {
                //ダメージを受けたアニメーションを再生
                Parent.gameObject.GetComponent<Dragon>().TakeDamage();
            }
        }
    }
}
