using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zone : MonoBehaviour
{
    public Image zoneSign;
    private CapsuleCollider zone;
    public Transform insideWalls;
    public Transform outsideWalls;

    public float zoneRadius = 600, dividedZone;
    float timerFirstZone = 6f, timerNextZone = 10f;
    private float deltaRadius = 0.03f; //vitesse de reduction de la zone
    public Vector3 centerZone = Vector3.zero; //definit le centre de la zone

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
        insideWalls.localScale = new Vector3(2300, 500, 2300);
        outsideWalls.localScale = new Vector3(2300, 500, 2300);

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
        insideWalls.position = centerZone;
        outsideWalls.position = centerZone;
        transform.position = centerZone;

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

    private void OnDrawGizmos()
    {
    }
}
