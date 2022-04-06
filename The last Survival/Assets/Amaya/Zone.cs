using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zone : MonoBehaviour
{
    [SerializeField]
    private float firstRadius;
    public RawImage inStormEffect;
    private CapsuleCollider zone;

    private void Start()
    {
        zone = GetComponent<CapsuleCollider>();
        zone.radius = firstRadius;
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "User")
        {
            Debug.Log("you are in safe area");
            inStormEffect.enabled = false;
            //other.gameObject.GetComponent<PVScript>().inStorm = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "User")
        {
            inStormEffect.enabled = true;
            Debug.Log("you are in the storm");
            //other.gameObject.GetComponent<PVScript>().inStorm = true;
        }
    }

    private void OnDrawGizmos()
    {
    }
}
