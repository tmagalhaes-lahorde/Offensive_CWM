using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//permite to tell the user if he's in safe zone or not 
public class nextZone : MonoBehaviour
{
    public Zone originZone;
    public CapsuleCollider newZone;

    private void Start()
    {
        newZone = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        //set the nextZone trigger on the zone center
        transform.position = new Vector3(originZone.centerZone.x, 0, originZone.centerZone.z);

        //collider set at the same time than the zone
        if (originZone.firstZoneEnabled)
        {
            newZone.radius = originZone.dividedZone;
        }

        //divide the radius every time the previous one met its limit
        if (originZone.stormLimit)
        {
            newZone.radius = newZone.radius / 2;
        }

        //define the limite that is equal to the last zone radius
        if(originZone.zone.radius <= 15)
        {
            newZone.radius = 15;
        }
    }
}
