using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Sword : MonoBehaviour
{

    public GameObject sparkEfect;

    public AudioClip sword;
    public AudioClip pari;

    AudioSource ad;

    public SteamVR_Action_Vibration vibration;
    public SteamVR_Input_Sources hand;

    // Start is called before the first frame update
    void Start()
    {
        ad = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyWeapon")
        {
            ad.PlayOneShot(pari);
        }


        if (collision.gameObject.tag != "Untagged")
        {
            ad.PlayOneShot(sword);
            vibration.Execute(0, 0.2f, 100, 1f, hand);

            foreach (ContactPoint contactPoint in collision.contacts)
            {
                GameObject effect = (GameObject)Instantiate(sparkEfect, (Vector3)contactPoint.point, Quaternion.identity);
            }
        }
    }
    

    // Update is called once per frame
    void Update()
    {

    }
}
