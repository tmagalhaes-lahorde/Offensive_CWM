using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zone : MonoBehaviour
{
    public Image zoneSign;
    public CapsuleCollider zone;
    public Transform insideWalls;
    public Transform outsideWalls;
    public Transform centerZoneTrans;

    public AudioSource zoneSource;
    public AudioClip zoneClip;

    public bool outNextZone;
    public float zoneRadius = 695, dividedZone;
    float timerFirstZone = 60f, timerNextZone = 120f;
    public float deltaRadius = 0.0165f; // reducing speed
    public Vector3 centerZone = Vector3.zero;

    private int i = 0;

    public bool stormActive = false, playSound,firstZoneEnabled = false;
    public bool stormLimit,shouldStart;
    private int nbStorm = 0;

    private void Start()
    {
        //Set all scales and disable objects that should not be appearing at the beginning
        zone = GetComponent<CapsuleCollider>();
        zone.radius = zoneRadius;
        insideWalls.gameObject.SetActive(false);
        outsideWalls.gameObject.SetActive(false);
        insideWalls.localScale = new Vector3(695, 500,695);
        outsideWalls.localScale = new Vector3(695, 500,695);

        //search all the players to find the zone center

        GameObject[] users = GameObject.FindGameObjectsWithTag("User");

        foreach(GameObject user in users)
        {
            centerZone += users[i].transform.position;
            i += 1;
        }

        centerZone /= i;

        //permite to find where itll stop to shrink
        dividedZone = zoneRadius / 2;
    }

    private void Update()
    {
        //define where the zone will be set up
        centerZone.y = 0;
        insideWalls.position = centerZone;
        outsideWalls.position = centerZone;
        transform.position = centerZone;
        centerZoneTrans.position = new Vector3(centerZone.x, 0, centerZone.z);
      
        if (stormActive == false)
        {
            
            //start the first zone

            timerFirstZone -= Time.deltaTime;

            if (timerFirstZone <= 0 && firstZoneEnabled == false)
            {
                insideWalls.gameObject.SetActive(true);
                outsideWalls.gameObject.SetActive(true);

                playSound = true;
                if (playSound)
                {
                    zoneSource.PlayOneShot(zoneClip);
                    timerFirstZone = 60;
                    firstZoneEnabled = true;
                    playSound = false;
                }
            }

            //once the first zone is enabled, we can start the second one
            if (firstZoneEnabled)
            {
                timerNextZone -= Time.deltaTime;
                if (timerNextZone <= 0)
                {
                    stormActive = true;
                }
            }
            
        }
        else if (stormActive == true)
        {
            //reduce the zone
            zone.radius -= deltaRadius;
            insideWalls.localScale = insideWalls.localScale - new Vector3(0.03f, 0, 0.03f);
            outsideWalls.localScale = outsideWalls.localScale - new Vector3(0.03f, 0, 0.03f);

            //set a limit
            if (zone.radius <= dividedZone)
            {
                stormLimit = true;
                stormActive = false;
            }
        }

        //redefine the next zone half radius
        if(stormLimit == true)
        {
            timerNextZone = 120f;
            dividedZone = zone.radius / 2;
            stormLimit = false;
        }

        //define the last zone radius
        if(zone.radius <= 15)
        {
            zone.radius = 15;
        }
    }
}
