using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    //新しく追加
    public GameObject PHP;

    private Animator animator;
    private AnimatorStateInfo animStateInfo;

    //変数
    public float dragonHP = 600;
    public float magicAttackCancel = 50;

    private int attack_Type;
    public int Attack_interval = 7;
    public int Breath_interval = 3;
    private int IceMagicAttack_interval = 16;

    private float tmpTime = 0;
    private float Breath_tmpTime = 0;
    private float IceMagicAttack_tmpTime = 0;
    private float speed = 3.0f;

    //攻撃の時に使うフラグたち↓
    //これがtureにならないとそもそも攻撃できない
    private bool attack_Flg = false;

    //噛みつき攻撃以外の攻撃の時にいったん時間を止めるフラグ
    private bool breath_Attack_Flg = false;

    //これがtrueの時にブレスを吐く
    private bool breath_Flg = true;

    //前後の移動に使うフラグ
    private bool idou_flg = true;
    private bool idou_flg2 = false;

    //ブレスを吐いてる時間を数えるフラグ
    private bool breath_time = true;

    //playerの爆発を一回しかさせないフラグ
    private bool playerEffect_flg = true;

    //魔法攻撃のフラグ
    public bool magicAttack_flg = false;

    //ブレス時の移動に使う,ここも変更する
    Vector3 endMarker = new Vector3(0, 50, 6);
    Vector3 endMarker2 = new Vector3(0, 50, 4);

    //エフェクトを使うため
    Transform Ciled = null;
    public GameObject MagicEffect;
    private GameObject PlayerEffect;

    //サウンド関係
    public AudioClip DragonVoice1;          //開幕の鳴き声と死ぬときの鳴き声
    public AudioClip DragonVoice2;          //噛みついた時とダメージを受けた時の鳴き声
    public AudioClip DragonVoice3;          //ブレスのSE

    //オーディオソース
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        //Animatorの取得
        animator = GetComponent<Animator>();

        PlayerEffect = GameObject.Find("Lift/Camera/Player/par1");

        //オーディオソースの取得
        audioSource = this.gameObject.GetComponent<AudioSource>();

        //初めのあいさつ
        animator.SetTrigger("Fly Cast Spell");
        audioSource.PlayOneShot(DragonVoice1);
    }

    // Update is called once per frame
    void Update()
    {
        //レイヤー番号をここに入れる
        animStateInfo = animator.GetCurrentAnimatorStateInfo(0);

        //attack_Flgがtrueの時にだけ攻撃する
        if (attack_Flg == true)
        {
            attack_Flg = false;

            //攻撃の種類を決める
            attack_Type = Random.Range(1, 5);

            //噛みつき攻撃
            if (attack_Type == 1)
            {
                Bite_Attack();
            }
        }


        //ブレスの攻撃
        if (attack_Type == 2)
        {
            breath_Attack_Flg = true;

            //ここを変える
            if (idou_flg == true && transform.position.z <= 6)
            {
                float step = speed * Time.deltaTime;

                transform.position = Vector3.MoveTowards(transform.position, endMarker, step);
            }

            //ブレスのために後ろに下がる処理
            if (transform.position.z == 6 && breath_Flg == true)
            {
                idou_flg = false;
                breath_Flg = false;
                animator.SetTrigger("Fly Fire Breath Attack");
                Ciled = transform.Find("RigHeadGizmo/FX-Fire Breath");
                Ciled.gameObject.GetComponent<ParticleSystem>().Play();
                audioSource.PlayOneShot(DragonVoice3);

                //ブレスの瞬間に-5HP減る処理
                PHP.gameObject.GetComponent<HPbar>().Set_HP();
            }

            //ブレスを吐き終わる処理
            if (breath_Flg == false && breath_time == true)
            {
                Breath_tmpTime += Time.deltaTime;

                if (Breath_tmpTime >= Breath_interval)
                {
                    breath_time = false;

                    animator.SetTrigger("Fly Fire Breath Attack");
                    Ciled = transform.Find("RigHeadGizmo/FX-Fire Breath");
                    Ciled.gameObject.GetComponent<ParticleSystem>().Stop();
                    idou_flg2 = true;
                }
            }

            //ここも変える
            //ブレスが終わって前に戻ってくる処理
            if (idou_flg2 == true && transform.position.z >= 4)
            {
                float step = speed * Time.deltaTime;

                transform.position = Vector3.MoveTowards(transform.position, endMarker2, step);

                if (transform.position.z == 4)
                {
                    idou_flg2 = false;
                    breath_Attack_Flg = false;
                    attack_Type = 999;
                }
            }
        }

        //魔法攻撃（爆発）
        if (attack_Type == 3)
        {
            breath_Attack_Flg = true;
            magicAttack_flg = true;

            animator.SetTrigger("MagicAttack");
            MagicEffect.gameObject.GetComponent<ParticleSystem>().Play();
            attack_Type = 999;
        }

        if (animStateInfo.fullPathHash == Animator.StringToHash("Base Layer.MagicAttack"))
        {
            //アニメーションの終了を感知
            if (animStateInfo.normalizedTime >= 0.8f)
            {
                MagicEffect.gameObject.GetComponent<ParticleSystem>().Stop();

                if (playerEffect_flg == true)
                {
                    playerEffect_flg = false;
                    PlayerEffect.GetComponent<PlayerEffect>().Play_Effect();
                    //爆発HP減る処理
                    PHP.gameObject.GetComponent<HPbar>().Set_HP2(150);
                }

                breath_Attack_Flg = false;
            }
        }

        //魔法攻撃（氷）
        if (attack_Type == 4)
        {
            //一回だけこの中を通る
            if(IceMagicAttack_tmpTime == 0)
            {
                breath_Attack_Flg = true;
                GameObject iceManager = GameObject.Find("IceManager");
                iceManager.GetComponent<IceManager>().iceMagicAttack_falg = true;
            }

            IceMagicAttack_tmpTime += Time.deltaTime;

            if(IceMagicAttack_tmpTime > IceMagicAttack_interval)
            {
                attack_Type = 999;
                breath_Attack_Flg = false;
                IceMagicAttack_tmpTime = 0;
            }
        }

        if (breath_Attack_Flg == false)
        {
            //秒数をカウントしていく
            tmpTime += Time.deltaTime;
        }

        //n秒間隔で攻撃
        if (tmpTime >= Attack_interval)
        {
            tmpTime = 0;
            attack_Flg = true;

            //ここでいろんなフラグを元に戻している
            Breath_tmpTime = 0;
            breath_Flg = true;
            idou_flg = true;
            idou_flg2 = false;
            breath_time = true;

            playerEffect_flg = true;
            magicAttack_flg = false;
            magicAttackCancel = 50;
            animator.SetInteger("Magicattack", 0);
        }
    }

    /// <summary>
    /// 倒れる処理
    /// </summary>
    public void Die()
    {
        animator.SetTrigger("Fly Die");
        audioSource.PlayOneShot(DragonVoice1);
    }

    public void Bite_Attack()
    {
        //噛みつき攻撃
        animator.SetTrigger("Fly Bite Attack");
        audioSource.PlayOneShot(DragonVoice2);

        Debug.Log("噛みつき");
    }

    /// <summary>
    /// ダメージ処理
    /// </summary>
    public void TakeDamage()
    {
        animator.SetTrigger("Fly Take Damage");

        //被弾ボイス
        audioSource.PlayOneShot(DragonVoice2);
    }

    /// <summary>
    /// キャンセルダメージ処理
    /// </summary>
    public void CancelTakeDamage()
    {
        animator.SetInteger("Magicattack", 21);

        MagicEffect.gameObject.GetComponent<ParticleSystem>().Stop();

        breath_Attack_Flg = false;

        //被弾ボイス
        audioSource.PlayOneShot(DragonVoice2);
    }
}
