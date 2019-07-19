using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGene : MonoBehaviour
{
    public GameObject Enemy1;       //普通の敵を入れてください
    public GameObject Enemy2;       //普通の敵を入れてください
    public GameObject Enemy3;       //弱点付きの敵を入れてください
    //public GameObject Lift;

    //最終的なプレイヤとの距離
    public float Enemy1_distance = 1.0f;
    public float Enemy2_distance = 1.0f;
    public float Enemy3_distance = 3.0f;

    //敵とプレイヤの最大距離
    private int px;

    //敵の最大生成数
    public int EnemyMax;
    public int EnemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        DropEnemy1();
        DropEnemy2();
        DropEnemy3();
        DropEnemy4();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyMax > EnemyCount)
        {
            int Type = Random.Range(1, 5);

            if(Type == 1)
            {
                DropEnemy1();
            }
            if (Type == 2)
            {
                DropEnemy2();
            }
            if (Type == 3)
            {
                DropEnemy3();
            }
            if (Type == 4)
            {
                DropEnemy4();
            }
        }
    }

    /// <summary>
    /// -40度から、0度の間に敵が生成される
    /// </summary>
    public void DropEnemy1()
    {
        Debug.Log(EnemyCount);
        int enemy = Random.Range(1, 4);             //生成される敵の種類
        Set_px();                                   //敵とプレイヤの最大距離を設定

        //EnemyCountに+1
        EnemyCount++;

        //生成される位置が-40度から0度の間の普通の敵
        if (enemy == 1)
        {
            GameObject go = Instantiate(Enemy1) as GameObject;

            int pz = Random.Range(-40, 1);                  //角度を設定する

            //度数法から弧度法に変換している
            float radian = pz * Mathf.PI / 180;

            float x2 = Mathf.Cos(radian) * px;              //最初のX座標
            float y2 = Mathf.Sin(radian) * px;              //最初のY座標(Z座標)

            float a2 = Mathf.Cos(radian) * Enemy1_distance;        //最後のX座標
            float b2 = Mathf.Sin(radian) * Enemy1_distance;        //最後のY座標(Z座標)

            //敵のスクリプトのInitialize関数に引数を渡す
            CactusScript cactus = go.GetComponent<CactusScript>();
            cactus.Initialize(x2, y2, a2, b2, pz);
        }

        //生成される位置が-40度から0度の間の普通の敵
        else if (enemy == 2)
        {
            GameObject go = Instantiate(Enemy2) as GameObject;

            int pz = Random.Range(-40, 1);                  //角度を設定する

            //度数法から弧度法に変換している
            float radian = pz * Mathf.PI / 180;

            float x2 = Mathf.Cos(radian) * px;              //最初のX座標
            float y2 = Mathf.Sin(radian) * px;              //最初のY座標(Z座標)

            float a2 = Mathf.Cos(radian) * Enemy2_distance;        //最後のX座標
            float b2 = Mathf.Sin(radian) * Enemy2_distance;        //最後のY座標(Z座標)

            //敵のスクリプトのInitialize関数に引数を渡す
            CactusScript cactus = go.GetComponent<CactusScript>();
            cactus.Initialize(x2, y2, a2, b2, pz);
        }

        //生成される位置が-40度から0度の間の弱点付きの敵
        else if (enemy == 3)
        {
            GameObject go = Instantiate(Enemy3) as GameObject;

            int pz = Random.Range(-40, 1);                  //角度を設定する

            //度数法から弧度法に変換している
            float radian = pz * Mathf.PI / 180;

            float x2 = Mathf.Cos(radian) * px;              //最初のX座標
            float y2 = Mathf.Sin(radian) * px;              //最初のY座標(Z座標)

            float a2 = Mathf.Cos(radian) * Enemy3_distance;        //最後のX座標
            float b2 = Mathf.Sin(radian) * Enemy3_distance;        //最後のY座標(Z座標)

            //敵のスクリプトのInitialize関数に引数を渡す
            DeathKnight deathKnight = go.GetComponent<DeathKnight>();
            deathKnight.Initialize(x2, y2, a2, b2, pz);
        }
    }

    /// <summary>
    /// 1度から、90度の間に敵が生成される
    /// </summary>
    public void DropEnemy2()
    {
        Debug.Log(EnemyCount);

        int enemy = Random.Range(1, 4);     //生成される敵の種類
        Set_px();                           //敵とプレイヤの最大距離を設定
        //EnemyCountに+1
        EnemyCount++;

        //生成される位置が1度から90度の間の普通の敵
        if (enemy == 1)
        {
            GameObject go = Instantiate(Enemy1) as GameObject;

            int pz = Random.Range(1, 91);                   //角度を設定する

            //度数法から弧度法に変換している
            float radian = pz * Mathf.PI / 180;

            float x2 = Mathf.Cos(radian) * px;              //最初のX座標
            float y2 = Mathf.Sin(radian) * px;              //最初のY座標(Z座標)

            float a2 = Mathf.Cos(radian) * Enemy1_distance;        //最後のX座標
            float b2 = Mathf.Sin(radian) * Enemy1_distance;        //最後のY座標(Z座標)

            //敵のスクリプトのInitialize関数に引数を渡す
            CactusScript cactus = go.GetComponent<CactusScript>();
            cactus.Initialize(x2, y2, a2, b2, pz);
        }

        //生成される位置が1度から90度の間の弱点付きの敵
        else if (enemy == 2)
        {
            GameObject go = Instantiate(Enemy2) as GameObject;

            int pz = Random.Range(1, 91);                   //角度を設定する

            //度数法から弧度法に変換している
            float radian = pz * Mathf.PI / 180;

            float x2 = Mathf.Cos(radian) * px;              //最初のX座標
            float y2 = Mathf.Sin(radian) * px;              //最初のY座標(Z座標)

            float a2 = Mathf.Cos(radian) * Enemy2_distance;        //最後のX座標
            float b2 = Mathf.Sin(radian) * Enemy2_distance;        //最後のY座標(Z座標)

            //敵のスクリプトのInitialize関数に引数を渡す
            CactusScript cactus = go.GetComponent<CactusScript>();
            cactus.Initialize(x2, y2, a2, b2, pz);
        }

        else if (enemy == 3)
        {
            GameObject go = Instantiate(Enemy3) as GameObject;

            int pz = Random.Range(1, 91);                   //角度を設定する

            //度数法から弧度法に変換している
            float radian = pz * Mathf.PI / 180;

            float x2 = Mathf.Cos(radian) * px;              //最初のX座標
            float y2 = Mathf.Sin(radian) * px;              //最初のY座標(Z座標)

            float a2 = Mathf.Cos(radian) * Enemy3_distance;        //最後のX座標
            float b2 = Mathf.Sin(radian) * Enemy3_distance;        //最後のY座標(Z座標)

            //敵のスクリプトのInitialize関数に引数を渡す
            DeathKnight deathKnight = go.GetComponent<DeathKnight>();
            deathKnight.Initialize(x2, y2, a2, b2, pz);
        }
    }

    /// <summary>
    /// 91度から、180度の間に敵が生成される
    /// </summary>
    public void DropEnemy3()
    {
        Debug.Log(EnemyCount);

        int enemy = Random.Range(1, 4);     //生成される敵の種類
        Set_px();                           //敵とプレイヤの最大距離を設定
        //EnemyCountに+1
        EnemyCount++;

        //生成される位置が91度から180度の間の普通の敵
        if (enemy == 1)
        {
            GameObject go = Instantiate(Enemy1) as GameObject;

            int pz = Random.Range(91, 181);                 //角度を設定する

            //度数法から弧度法に変換している
            float radian = pz * Mathf.PI / 180;

            float x2 = Mathf.Cos(radian) * px;              //最初のX座標
            float y2 = Mathf.Sin(radian) * px;              //最初のY座標(Z座標)

            float a2 = Mathf.Cos(radian) * Enemy1_distance;        //最後のX座標
            float b2 = Mathf.Sin(radian) * Enemy1_distance;        //最後のY座標(Z座標)

            //敵のスクリプトのInitialize関数に引数を渡す
            CactusScript cactus = go.GetComponent<CactusScript>();
            cactus.Initialize(x2, y2, a2, b2, pz);
        }

        //生成される位置が91度から180度の間の弱点付きの敵
        else if (enemy == 2)
        {
            GameObject go = Instantiate(Enemy2) as GameObject;

            int pz = Random.Range(91, 181);                 //角度を設定する

            //度数法から弧度法に変換している
            float radian = pz * Mathf.PI / 180;

            float x2 = Mathf.Cos(radian) * px;              //最初のX座標
            float y2 = Mathf.Sin(radian) * px;              //最初のY座標(Z座標)

            float a2 = Mathf.Cos(radian) * Enemy2_distance;        //最後のX座標
            float b2 = Mathf.Sin(radian) * Enemy2_distance;        //最後のY座標(Z座標)

            //敵のスクリプトのInitialize関数に引数を渡す
            CactusScript cactus = go.GetComponent<CactusScript>();
            cactus.Initialize(x2, y2, a2, b2, pz);
        }

        else if (enemy == 3)
        {
            GameObject go = Instantiate(Enemy3) as GameObject;

            int pz = Random.Range(91, 181);                 //角度を設定する

            //度数法から弧度法に変換している
            float radian = pz * Mathf.PI / 180;

            float x2 = Mathf.Cos(radian) * px;              //最初のX座標
            float y2 = Mathf.Sin(radian) * px;              //最初のY座標(Z座標)

            float a2 = Mathf.Cos(radian) * Enemy3_distance;        //最後のX座標
            float b2 = Mathf.Sin(radian) * Enemy3_distance;        //最後のY座標(Z座標)

            //敵のスクリプトのInitialize関数に引数を渡す
            DeathKnight deathKnight = go.GetComponent<DeathKnight>();
            deathKnight.Initialize(x2, y2, a2, b2, pz);
        }
    }

    /// <summary>
    /// 181度から、-220度の間に敵が生成される
    /// </summary>
    public void DropEnemy4()
    {
        Debug.Log(EnemyCount);
        int enemy = Random.Range(1, 4);     //生成される敵の種類
        Set_px();                           //敵とプレイヤの最大距離を設定
        //EnemyCountに+1
        EnemyCount++;

        //生成される位置が181度から220度の間の普通の敵
        if (enemy == 1)
        {
            GameObject go = Instantiate(Enemy1) as GameObject;

            int pz = Random.Range(181, 221);                //角度を設定する

            //度数法から弧度法に変換している
            float radian = pz * Mathf.PI / 180;

            float x2 = Mathf.Cos(radian) * px;              //最初のX座標
            float y2 = Mathf.Sin(radian) * px;              //最初のY座標(Z座標)

            float a2 = Mathf.Cos(radian) * Enemy1_distance;        //最後のX座標
            float b2 = Mathf.Sin(radian) * Enemy1_distance;        //最後のY座標(Z座標)

            //敵のスクリプトのInitialize関数に引数を渡す
            CactusScript cactus = go.GetComponent<CactusScript>();
            cactus.Initialize(x2, y2, a2, b2, pz);
        }

        //生成される位置が181度から220度の間の弱点付きの敵
        else if (enemy == 2)
        {
            GameObject go = Instantiate(Enemy2) as GameObject;

            int pz = Random.Range(181, 221);                //角度を設定する

            //度数法から弧度法に変換している
            float radian = pz * Mathf.PI / 180;

            float x2 = Mathf.Cos(radian) * px;              //最初のX座標
            float y2 = Mathf.Sin(radian) * px;              //最初のY座標(Z座標)

            float a2 = Mathf.Cos(radian) * Enemy2_distance;        //最後のX座標
            float b2 = Mathf.Sin(radian) * Enemy2_distance;        //最後のY座標(Z座標)

            //敵のスクリプトのInitialize関数に引数を渡す
            CactusScript cactus = go.GetComponent<CactusScript>();
            cactus.Initialize(x2, y2, a2, b2, pz);
        }

        else if (enemy == 3)
        {
            GameObject go = Instantiate(Enemy3) as GameObject;

            int pz = Random.Range(181, 221);                //角度を設定する

            //度数法から弧度法に変換している
            float radian = pz * Mathf.PI / 180;

            float x2 = Mathf.Cos(radian) * px;              //最初のX座標
            float y2 = Mathf.Sin(radian) * px;              //最初のY座標(Z座標)

            float a2 = Mathf.Cos(radian) * Enemy3_distance;        //最後のX座標
            float b2 = Mathf.Sin(radian) * Enemy3_distance;        //最後のY座標(Z座標)

            //敵のスクリプトのInitialize関数に引数を渡す
            DeathKnight deathKnight = go.GetComponent<DeathKnight>();
            deathKnight.Initialize(x2, y2, a2, b2, pz);
        }
    }

    /// <summary>
    /// 変数pxのセッター関数
    /// </summary>
    private void Set_px()
    {
        px = Random.Range(20, 26);
    }

    /// <summary>
    /// EnemyCountのセッター関数
    /// </summary>
    public void Set_EnemyCount()
    {
        EnemyCount--;
    }
}