using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public AudioClip shield;
    public GameObject sparkEfect;

    AudioSource ad;

    // Start is called before the first frame update
    void Start()
    {
        ad = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyWeapon")
        {
            ad.PlayOneShot(shield);

            foreach (ContactPoint contactPoint in collision.contacts)
            {
                GameObject effect = (GameObject)Instantiate(sparkEfect, (Vector3)contactPoint.point, Quaternion.identity);
            }
        }
    }
}
