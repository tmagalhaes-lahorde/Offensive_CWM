using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public Camera Cam;
    private float range = 100f, damage = 10;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        if(Physics.Raycast(Cam.transform.position,Cam.transform.forward,out hit, range,7))
        {
            Debug.Log(hit.transform.gameObject.name) ;
        }
    }
}
