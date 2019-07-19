using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrethDragon : MonoBehaviour
{
    public GameObject FireBall;

    //スタートとゴールの位置を指定
    private Vector3 startMarker = new Vector3();            //スタート地点
    private Vector3 endMarker = new Vector3(0, 3, 15);       //ゴール地点

    //二点間の距離を入れる変数
    public float distance_two;

    //敵が生成されてからの時間を入れておく変数
    private float starttime;

    private Animator animator;

    //スピード
    public float speed = 50.0f;

    //時間をはかるための変数
    float interval = 2.0f;
    float tmpTime = 0.0f;

    bool breth_flg = true;

    //サウンド関係
    public AudioClip DragonVoice;
    public AudioClip BrethSE;

    //オーディオソース
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //最初の時間を入れる
        starttime = Time.time;

        //Animatorコンポーネントの取得
        animator = GetComponent<Animator>();

        startMarker = this.transform.position;

        //二点間の距離を代入
        distance_two = Vector3.Distance(startMarker, endMarker);

        //まずは一回鳴かせる
        audioSource.PlayOneShot(DragonVoice);
    }

    // Update is called once per frame
    void Update()
    {
        //現在の位置を計算
        float present_Location = (Time.time - starttime) * speed / distance_two;

        //Lerpを使って敵を動かす
        transform.position = Vector3.Lerp(startMarker, endMarker, present_Location);

        Vector3 pos = transform.position;

        if(endMarker == pos)
        {
            animator.SetBool("Idle", true);

            tmpTime += Time.deltaTime;

            if(tmpTime > interval && breth_flg == true)
            {
                breth_flg = false;
                animator.SetTrigger("Breth");
                Invoke("CreateFireBall", 0.8f);

                //ブレスのSE
                audioSource.PlayOneShot(BrethSE);
            }
        }
    }

    private void CreateFireBall()
    {
        GameObject go = Instantiate(FireBall) as GameObject;
    }
}
