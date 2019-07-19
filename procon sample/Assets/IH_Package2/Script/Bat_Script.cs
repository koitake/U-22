using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bat_Script : MonoBehaviour
{
    //敵の背の高さ
    const float ENEMY_Y_POS = -50.0f;

    //HP関係
    private float maxEnemyHP = 30;
    private float enemyHP = 30;
    public Slider slider;


    //生成されたときの角度を入れておく変数
    private int get_angle;

    //敵が生成されてからの時間を入れておく変数
    private float starttime;

    //スタートとゴールの位置を指定
    private Vector3 startMarker = new Vector3();            //スタート地点
    private Vector3 endMarker = new Vector3();              //ゴール地点

    private Animator animator;
    private AnimatorStateInfo animStateInfo;

    //スピード
    public float speed = 1.0f;

    //二点間の距離を入れる変数
    public float distance_two;

    //関数の呼び出しに使う
    public bool flg = false;
    private bool die_flg = false;

    //時間をはかるための変数
    float interval = 3.0f;
    float tmpTime = 0.0f;
    float voiceInterval = 4.0f;
    float voiceTmptime = 0.0f;
    float Attack_interval = 4.0f;
    float Attack_tmpTime = 0.0f;

    //プレイヤの座標を入れる
    public Transform targetPlayer;

    //ワープをどの程度の位置に置くか
    public Vector3 offset = new Vector3();

    //生成するワープのプレファブ
    public GameObject warpPrefab;

    //EnemyGeneratorのスクリプトにアクセスするため
    GameObject generator;
    underground enemygene;

    //リフトの座標を入れる
    Vector3 lift;

    //サウンド関係
    public AudioClip BatVoice;

    //オーディオソース
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //最初の時間を入れる
        starttime = Time.time;

        //Animatorコンポーネントの取得
        animator = GetComponent<Animator>();

        //Playerの方を向くようにする
        transform.root.LookAt(targetPlayer);

        //ワープ生成
        Generate();

        //EnemyGeneratorのスクリプトにアクセスする
        generator = GameObject.Find("UnderGenerator");
        enemygene = generator.GetComponent<underground>();

        //HPの初期化
        slider.maxValue = maxEnemyHP;
        slider.value = enemyHP;
    }

    // Update is called once per frame
    void Update()
    {

        //体力がなくなったら
        if (enemyHP <= 0)
        {
            Die();
        }

        //リフトの座標を取得
        lift = GameObject.Find("Lift").transform.position;

        //レイヤー番号をここに入れる
        animStateInfo = animator.GetCurrentAnimatorStateInfo(0);

        //現在の位置を計算
        float present_Location = (Time.time - starttime) * speed / distance_two;

        //Dieのアニメーションにいないときは動かす
        if (animStateInfo.fullPathHash != Animator.StringToHash("Base Layer.Die"))
        {
            //Lerpを使って敵を動かす
            transform.position = Vector3.Lerp(startMarker, endMarker, present_Location);
        }

        //敵がPlayerの目の前まで来たら攻撃する処理
        Vector3 pos = transform.position;

        if (pos == endMarker && flg == false && die_flg == false)
        {
            //秒数をカウントしていく
            Attack_tmpTime += Time.deltaTime;

            //n秒より大きくなったら攻撃
            if (Attack_tmpTime >= Attack_interval)
            {
                animator.SetTrigger("BiteAttack");
                Attack_tmpTime = 0;
            }
        }


        //攻撃の時だけ当たり判定をなくす
        if (animStateInfo.fullPathHash == Animator.StringToHash("Base Layer.BiteAttack"))
        {
            if (animStateInfo.normalizedTime < 0.8f)
            {
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            else
            {
                this.gameObject.GetComponent<BoxCollider>().enabled = true;
            }
        }




        //flgの中がtrueになったらスタンの処理を実行する
        if (flg == true)
        {
            Stan();

            //秒数をカウントしていく
            tmpTime += Time.deltaTime;

            //n秒より大きくなったらスタンから回復
            if (tmpTime >= interval)
            {
                Recovery();
                tmpTime = 0;
            }
        }

        //Dieのアニメーションにいるとき
        if (animStateInfo.fullPathHash == Animator.StringToHash("Base Layer.Die"))
        {
            //アニメーションの終了を感知
            if (animStateInfo.normalizedTime >= 1.0f)
            {

                if (-40 <= get_angle && get_angle <= 0)
                {
                    enemygene.Set_EnemyCount();
                }
                else if (1 <= get_angle && get_angle <= 90)
                {
                    enemygene.Set_EnemyCount();
                }
                else if (91 <= get_angle && get_angle <= 180)
                {
                    enemygene.Set_EnemyCount();
                }
                else if (181 <= get_angle && get_angle <= 220)
                {
                    enemygene.Set_EnemyCount();
                }
                FindObjectOfType<Scoreunder>().AddPoint(100);

                Destroy(this.gameObject);
            }
        }

        //リフトが動いたら消す処理
        if (lift.y >= ENEMY_Y_POS) Destroy(this.gameObject);

        //秒数をカウントしていく
        voiceTmptime += Time.deltaTime;

        //4秒に一回鳴かせる
        if (voiceTmptime > voiceInterval)
        {
            audioSource.PlayOneShot(BatVoice);
            voiceTmptime = 0;
        }
    }

    /// <summary>
    /// スタン処理
    /// </summary>
    private void Stan()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = true;

        animator.SetBool("Take Damage", true);
    }

    /// <summary>
    /// スタン回復処理
    /// </summary>
    private void Recovery()
    {
        flg = false;
        animator.SetBool("Take Damage", false);
    }

    /// <summary>
    /// 初期位置設定関数, 到達地点設定関数
    /// </summary>
    /// <param name="x"></param>
    /// <param name="z"></param>
    /// <param name="a"></param>
    /// <param name="b"></param>
    public void Initialize(float x, float z, float a, float b, int pz)
    {
        //角度を取得
        get_angle = pz;

        //生成された瞬間の場所をstartMarkerにセットする
        startMarker.Set(x, ENEMY_Y_POS, z);

        transform.position = startMarker;

        endMarker.Set(a, ENEMY_Y_POS, b);

        //二点間の距離を代入
        distance_two = Vector3.Distance(startMarker, endMarker);
    }

    /// <summary>
    /// 剣が当たったら敵が倒れる処理
    /// </summary>
    /// <param name="col"></param>
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Seaber")
        {
            Death_Seaber();
        }
        if (col.gameObject.tag == "Sword")
        {
            float damagePoint = Sword_Player.Get_SwordPower();

            enemyHP -= damagePoint;

            slider.value = enemyHP;
        }
    }

    /// <summary>
    /// 倒されたときの処理
    /// </summary>
    public void Die()      //プレイヤの剣に当たると発動
    {
        die_flg = true;

        if (die_flg == true)
        {
            animator.SetBool("Die", true);
        }
    }

    /// <summary>
    /// ワープの生成処理
    /// </summary>
    private void Generate()
    {
        //位置を決定
        Vector3 position = transform.position +
            transform.up * offset.y +
            transform.right * offset.x +
            transform.forward * offset.z;

        //生成
        Instantiate(warpPrefab, position, transform.rotation);
    }

    /// <summary>
    /// 必殺技で死んだとき
    /// </summary>
    private void Death_Seaber()
    {
        if (-40 <= get_angle && get_angle <= 0)
        {
            enemygene.Set_EnemyCount();
        }
        else if (1 <= get_angle && get_angle <= 90)
        {
            enemygene.Set_EnemyCount();
        }
        else if (91 <= get_angle && get_angle <= 180)
        {
            enemygene.Set_EnemyCount();
        }
        else if (181 <= get_angle && get_angle <= 220)
        {
            enemygene.Set_EnemyCount();
        }

        //スコアを足す処理
        FindObjectOfType<Score>().AddPoint(100);

        Destroy(this.gameObject);
    }
}
