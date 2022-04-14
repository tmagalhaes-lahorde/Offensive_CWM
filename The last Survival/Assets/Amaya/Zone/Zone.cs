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
    public float zoneRadius = 600, dividedZone;
    float timerFirstZone = 2f, timerNextZone = 3f;
    public float deltaRadius = 0.0165f; //vitesse de reduction de la zone
    public Vector3 centerZone = Vector3.zero; //definit le centre de la zone

    private int i = 0;

    public bool stormActive = false, playSound,firstZoneEnabled = false;
    public bool stormLimit,shouldStart;
    private int nbStorm = 0;

    private void Start()
    {
        zone = GetComponent<CapsuleCollider>();
        zone.radius = zoneRadius;
        insideWalls.gameObject.SetActive(false);
        outsideWalls.gameObject.SetActive(false);
        insideWalls.localScale = new Vector3(695, 500,695);
        outsideWalls.localScale = new Vector3(695, 500,695);

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
        centerZone.y = 0;
        insideWalls.position = centerZone;
        outsideWalls.position = centerZone;
        transform.position = centerZone;
        centerZoneTrans.position = new Vector3(centerZone.x, 0, centerZone.z);
      
        if (stormActive == false)
        {
            
            timerFirstZone -= Time.deltaTime;

            if (timerFirstZone <= 0 && firstZoneEnabled == false)
            {
                insideWalls.gameObject.SetActive(true);
                outsideWalls.gameObject.SetActive(true);

                playSound = true;
                if (playSound)
                {
                    zoneSource.PlayOneShot(zoneClip);
                    timerFirstZone = 10;
                    firstZoneEnabled = true;
                    playSound = false;
                }
            }

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
            zone.radius -= deltaRadius;
            insideWalls.localScale = insideWalls.localScale - new Vector3(0.03f, 0, 0.03f);
            outsideWalls.localScale = outsideWalls.localScale - new Vector3(0.03f, 0, 0.03f);

            if (zone.radius <= dividedZone)
            {
                stormLimit = true;
                stormActive = false;
            }
        }

        if(stormLimit == true)
        {
            timerNextZone = 10f;
            dividedZone = zone.radius / 2;
            stormLimit = false;
        }

        if(zone.radius <= 15)
        {
            zone.radius = 15;
        }
    }
}
