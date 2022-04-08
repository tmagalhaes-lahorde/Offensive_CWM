using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public Camera Cam;
    private float range = 100f, damage = 10;
    public AmmowScript count;
   
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
            count.Currentammow -= 1;
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        if(Physics.Raycast(Cam.transform.position,Cam.transform.forward,out hit, range,7))
        {
        }
    }
}
