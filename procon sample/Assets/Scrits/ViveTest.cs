using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using UnityEngine.SceneManagement;

public class ViveTest : MonoBehaviour
{
    public Vector3 maxScale;

    public GameObject Lightsaber;
    public GameObject Lightsaber2;
    public GameObject Lightsaber3;
    public GameObject guageText;
    public GameObject guage;
    public GameObject aura;
    public GameObject aura2;
    public GameObject aura3;
    public GameObject deathBlow;
    public GameObject hpBar;


    public bool grab;
    public bool wg;


    public float gauge;
    float time = 0;

    public float testVikilt;

    public GameObject mic;

    AudioSource audioSource;

    public GameObject gripChargeSE;
    public AudioClip triggerSwordSE;

    public SteamVR_Input_Sources hand;
    public SteamVR_Action_Single Trigger;
    public SteamVR_Action_Boolean grabAction;
    public SteamVR_Action_Vibration vibration;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //// grabActionがオンになったら
        //bool grab = grabAction.GetState(hand);
        //if (grab == true)
        //{
        //    //マイクON
        //    mic.SetActive(true);
        //    guage.SetActive(true);
        //    //握った時の音とゲージのチャージ音
        //    //audioSource.PlayOneShot(gripChargeSE);
        //    this.gameObject.GetComponent<AudioSource>().enabled = true;

        //    if (time <= 5)
        //    {

        //        vibration.Execute(0, 5.0f, 100, 1f, hand);
        //        time += Time.deltaTime;

        //        //握っている間に叫んでゲージをためる
        //        if (time < 5)
        //        {
        //            gauge += mic.GetComponent<Mic>().m_volumeRate * testVikilt;
        //        }
        //        else if (time >= 5)
        //        {
        //            mic.SetActive(false);
        //            //ゲージ減少
        //            gauge -= Time.deltaTime * 2;
        //        }
        //        Debug.Log(gauge);
        //    }

        //}
        ////triggerがオンになったら
        ////トリガーを引いた時点で必殺剣が出てゲージが減り始める
        //float tri = Trigger.GetAxis(hand);

        //if (time >= 5 && tri == 1)
        //{
        //    audioSource.PlayOneShot(triggerSwordSE);
        //    Lightsaber.SetActive(true);
        //}
        //if (gauge == 0)
        //{
        //    Lightsaber.SetActive(false);
        //    guage.SetActive(false);
        //}
        //else
        //{
        //    time = 0;
        //}


        //bool losepanel = GetComponent<HPbar>().lose;
        float tri = Trigger.GetAxis(hand);
        Debug.Log(tri);

        //if (losepanel == true && tri == 1)
        //{
        //    Debug.Log("a");
        //    SceneManager.LoadScene("Field");
        //}

        wg = deathBlow.GetComponent<Deathblow>().deathbloe;
        //if (wg == true)
        //{
            grab = grabAction.GetState(hand);
            if (grab == true)
            {
                deathBlow.GetComponent<Deathblow>().deathbloe = false;
                if (time <= 5)
                {
                    aura.SetActive(true);
                    aura2.SetActive(true);
                    aura3.SetActive(true);
                    guage.SetActive(true);
                    gripChargeSE.SetActive(true);
                    time += Time.deltaTime;
                    mic.SetActive(true);
                    gauge += mic.GetComponent<Mic>().m_volumeRate * testVikilt;
                    vibration.Execute(0, 0.2f, gauge * 2, 1f, hand);
                }
                else
                {
                    mic.SetActive(false);
                }
            }
            if (grab == false)
            {
                aura.SetActive(false);
                aura2.SetActive(false);
                aura3.SetActive(false);
                time = 0;
                gripChargeSE.SetActive(false);
            }
            if (gauge >= 0)
            {
                if (tri == 1)
                {
                    this.gameObject.GetComponent<AudioSource>().enabled = true;
                    Lightsaber.SetActive(true);
                    Lightsaber2.SetActive(true);
                    Lightsaber3.SetActive(true);
                    aura.SetActive(false);
                    aura2.SetActive(false);
                    aura3.SetActive(false);
                }
                if (Lightsaber.active)
                {
                    gauge -= Time.deltaTime * 2;
                }
            }
            if (gauge <= 0)
            {
                Lightsaber.SetActive(false);
                Lightsaber2.SetActive(false);
                Lightsaber3.SetActive(false);
                guage.SetActive(false);
                this.gameObject.GetComponent<AudioSource>().enabled = false;
                gauge = 0;
            }
        //}
    }
}
