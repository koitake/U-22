using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // bullet prefab
    public GameObject arrow;

    // 弾丸発射点
    public Transform muzzle;

    public float span = 1;
    float count;

    // 弾丸の速度
    public float speed = -1000;

    AudioSource ad;

    // Use this for initialization
    void Start()
    {
        ad = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;

        if (count > span)
        {
            // 弾丸の複製
            GameObject bullets = Instantiate(arrow) as GameObject;

            Vector3 force;

            force = this.gameObject.transform.forward * speed;

            // Rigidbodyに力を加えて発射
            bullets.GetComponent<Rigidbody>().AddForce(force);

            // 弾丸の位置を調整
            bullets.transform.position = muzzle.position;

            count = 0f;
        }
    }
}
