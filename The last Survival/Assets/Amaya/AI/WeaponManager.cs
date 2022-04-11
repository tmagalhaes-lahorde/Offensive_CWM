using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private AudioSource _AudioSource;

    public float range = 100.0f;

    public int bulletsPerMag = 31; // Nombre de balles par chargeurs
    public int bulletsleft = 310;  // Notre réserve de balles 
    public int currentBullets;  // Balles chargées
    public int bulletDammage = 5; // Dégats de la balle

    public float fireRate = 0.1f;

    private float fireTimer;

    public Transform shootPoint;
    

    // Start is called before the first frame update
    void Start()
    {
        currentBullets = bulletsPerMag;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            Fire();
         
        }

        if (fireTimer < fireRate)
            fireTimer += Time.deltaTime;
    }

    private void Fire()
    {
        if (fireTimer < fireRate) return;

        RaycastHit hit;

        if (Physics.Raycast(shootPoint.position,shootPoint.transform.forward,out hit, range))

        {
            Debug.Log(hit.transform.name + "has been found");
                        
        }

        if (hit.collider.gameObject.GetComponent<Receive_Action>() != null)
        {
            hit.collider.gameObject.GetComponent<Receive_Action>().GetDammage(bulletDammage);

        }
        currentBullets--;
        fireTimer = 0.0f;
        PlayShootSound();

    }

    private void PlayEmptySound()
    {

    }

    private void PlayShootSound()
    {

    }
}
