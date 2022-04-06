using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zone : MonoBehaviour
{
    public RawImage inStormEffect;
    private CapsuleCollider zone;
    public Transform insideWalls;
    public Transform outsideWalls;

    public float zoneRadius = 30, dividedZone = 15f;
    float timerFirstZone = 6f, timerNextZone = 10f;
    private float deltaRadius = 0.001f; //vitesse de reduction de la zone
    private Vector3 centerZone = Vector3.zero; //definit le centre de la zone

    private int i = 0;

    public bool stormActive = false;
    private bool stormLimit,shouldStart;
    private int nbStorm = 0;

    private void Start()
    {
        zone = GetComponent<CapsuleCollider>();
        zone.radius = zoneRadius;
        insideWalls.gameObject.SetActive(false);
        outsideWalls.gameObject.SetActive(false);
        GameObject[] users = GameObject.FindGameObjectsWithTag("User");
        foreach(GameObject user in users)
        {
            centerZone += users[i].transform.position;
            i += 1;
        }
        
        centerZone /= i;
        dividedZone = zoneRadius / 2;
    }

    private void Update()
    {
        transform.position = centerZone;
        insideWalls.position = transform.position;
        outsideWalls.position = transform.position;

        Debug.Log(timerNextZone);

        if (stormActive == false)
        {   

            timerFirstZone -= Time.deltaTime;

            if(timerFirstZone <= 0)
            {
                insideWalls.gameObject.SetActive(true);
                outsideWalls.gameObject.SetActive(true);

                timerNextZone -= Time.deltaTime;

                if (timerNextZone <= 0)
                {
                    Debug.Log("coucou");
                    stormActive = true;
                }
            }
        }
        else if (stormActive == true)
        {
            nbStorm += 1;
            zoneRadius -= deltaRadius;
            insideWalls.localScale = insideWalls.localScale - new Vector3(0.00335f, 0, 0.00335f);
            outsideWalls.localScale = outsideWalls.localScale - new Vector3(0.00335f, 0, 0.00335f);
            zone.radius = zoneRadius;

            if (zone.radius <= dividedZone)
            {
                stormLimit = true;
                stormActive = false;
            }
        }

        if(stormLimit == true)
        {
            timerNextZone = 10f;
            dividedZone = zoneRadius / 2;
            stormLimit = false;
        }
    }

    //IEnumerator manageStorm()
    //{
    //    float nextZone = 5f;
    //    nextZone -= Time.deltaTime;
    //    Debug.Log(nextZone);
    //    if (nextZone <= 0)
    //    {
    //        nbStorm += 1;
    //        stormActive = true;
    //    }
    //    yield return new WaitForSeconds(1);
    //}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "User")
        {
            //Debug.Log("you are in safe area");
            inStormEffect.enabled = false;
            //other.gameObject.GetComponent<PVScript>().inStorm = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "User")
        {
            inStormEffect.enabled = true;
            //Debug.Log("you are in the storm");
            //other.gameObject.GetComponent<PVScript>().inStorm = true;
        }
    }

    private void OnDrawGizmos()
    {
    }
}
