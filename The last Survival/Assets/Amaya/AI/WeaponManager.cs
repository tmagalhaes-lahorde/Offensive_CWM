using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private AudioSource _AudioSource;

    public float range;

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
            GetComponent<AmmowScript>().Currentammow -= 1;
        }

        if (fireTimer < fireRate)
            fireTimer += Time.deltaTime;
    }

    private void Fire()
    {
        if (fireTimer < fireRate) return;

        RaycastHit hit;

        if (Physics.Raycast(transform.position,transform.forward,out hit, 200))
        {
            Debug.Log(hit.transform.name + "has been found");

            if (hit.collider.gameObject.GetComponent<CibleScript>() != null)
            {
                hit.collider.gameObject.GetComponent<CibleScript>().nbHealth -= 10;

            }
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

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.red);
    }
}
