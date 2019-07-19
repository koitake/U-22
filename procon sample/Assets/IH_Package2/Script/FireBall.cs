using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public int speed = 20;
    Vector3 endPos = new Vector3(0, 0, 0);

    public AudioClip audioClip;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float stop = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, endPos, stop);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Ground")
        {
            audioSource.PlayOneShot(audioClip);
            Destroy(this.gameObject);
        }
    }
}
