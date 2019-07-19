using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceManager : MonoBehaviour
{
    public GameObject IceLight1;
    public GameObject IceLight2;
    public GameObject IceLeft1;
    public GameObject IceLeft2;

    public bool iceMagicAttack_falg = false;
    private bool Create_flg1 = true;
    private bool Create_flg2 = true;
    private bool Create_flg3 = true;

    private float Create_interval = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (iceMagicAttack_falg == true)
        {
            Create_interval += Time.deltaTime;

            if (Create_interval > 0 && Create_flg1 == true)
            {
                Create_flg1 = false;
                GameObject go = Instantiate(IceLight1) as GameObject;
            }
            else if (Create_interval > 2 && Create_flg2 == true)
            {
                Create_flg2 = false;
                GameObject go = Instantiate(IceLight2) as GameObject;
            }
            else if (Create_interval > 4 && Create_flg3 == true)
            {
                Create_flg3 = false;
                GameObject go = Instantiate(IceLeft1) as GameObject;
            }
            else if (Create_interval > 6)
            {
                GameObject go = Instantiate(IceLeft2) as GameObject;
                iceMagicAttack_falg = false;
                Create_flg1 = true;
                Create_flg2 = true;
                Create_flg3 = true;
                Create_interval = 0;
            }
        }
    }
}
