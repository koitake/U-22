using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Player : MonoBehaviour
{
    public static float swordPower = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static float Get_SwordPower()
    {
        return swordPower;
    }

    //第二進化
    public static void Set_SwordPower2()
    {
        swordPower = 15;
    }

    //第三進化
    public static void Set_SwordPower3()
    {
        swordPower = 30;
    }
}
