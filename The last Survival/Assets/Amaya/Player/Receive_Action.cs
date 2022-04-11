using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receive_Action : MonoBehaviour
{

    public int maxHitpoint = 10;

    public int hitpoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        hitpoint = maxHitpoint;
    }

    public void GetDammage(int dammage)
    {

        hitpoint -= dammage;

        if (hitpoint<1)
        {
            Destroy(gameObject);
        }
    }
}
