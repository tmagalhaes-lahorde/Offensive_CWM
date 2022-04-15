using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        transform.position = new Vector3(originZone.centerZone.x, 0, originZone.centerZone.z);

        if (originZone.firstZoneEnabled)
        {
            newZone.radius = originZone.dividedZone;
        }

        if (originZone.stormLimit)
        {
            newZone.radius = newZone.radius / 2;
        }

        if(originZone.zone.radius <= 15)
        {
            newZone.radius = 15;
        }
    }
}
