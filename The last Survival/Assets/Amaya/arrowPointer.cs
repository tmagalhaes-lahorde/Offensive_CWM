using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowPointer : MonoBehaviour
{
    [SerializeField]
    private Transform targetCenterZone;
    Vector3 zoneDir;

    float rotationy;
    void Update()
    {
        zoneDir = targetCenterZone.position - transform.position;
        rotationy = Mathf.Clamp(rotationy, 0, 0);
        transform.forward = new Vector3(zoneDir.x,rotationy,zoneDir.z);
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, zoneDir, Color.red);
    }
}
