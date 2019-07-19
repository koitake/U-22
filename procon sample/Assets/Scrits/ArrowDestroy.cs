using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDestroy : MonoBehaviour
{

    public GameObject arrowDestroyEfect;
    public AudioClip arrowDestroySound;

    AudioSource ad;

    private void Start()
    {
        ad = GetComponent<AudioSource>();
    }

    private void Update()
    {
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sword")
        {
            foreach (ContactPoint contactPoint in collision.contacts)
            {
                GameObject effect = (GameObject)Instantiate(arrowDestroyEfect, (Vector3)contactPoint.point, Quaternion.identity);
            }

            ad.PlayOneShot(arrowDestroySound);

            Destroy(this.gameObject);
        }
    }
}
