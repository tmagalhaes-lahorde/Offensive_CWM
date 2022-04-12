using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Camera HeadPlayer;
    public CharacterController charactercontroller;
    public LineRenderer goToZone;

    private Vector3 Deplacements;
    private Zone inZone;
    private PVScript Health;

    public bool Grounded, Running;

    private int nbAmmo;
    public float LimitRotation = 30.0f, sensivity = 10.0f, angle, rotationx = 0, timerShoot = 0.1f;

    private float runningSpeed = 30f, walkingSpeed = 15f,gravity = 9, jumpForce =5;

    private void Start()
    {
        charactercontroller = GetComponent<CharacterController>();
        nbAmmo = gameObject.GetComponent<AmmowScript>().Currentammow;
    }
    void Update()
    {
        //------------DEPLACEMENT AXES X ET Z --------------------//

        Vector3 z = transform.TransformDirection(Vector3.forward);
        Vector3 x = transform.TransformDirection(Vector3.right);

        float speedZ = Input.GetAxis("Vertical");
        float speedX = Input.GetAxis("Horizontal");
        float speedY = Deplacements.y;

        if (Input.GetKey(KeyCode.LeftShift))
            Running = true;
        else Running = false;

        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedX *= runningSpeed;
            speedZ *= runningSpeed;
        }
        else
        {
            speedX *= walkingSpeed;
            speedZ *= walkingSpeed;
        }
        Deplacements = z * speedZ + x * speedX; 

        //-----------DEPLACEMENT AXE Y -------------------//

        if (charactercontroller.isGrounded && Input.GetButton("Jump"))
        {
            Deplacements.y = jumpForce;
        }
        else
        {
            Deplacements.y = speedY;
        }

        if (!charactercontroller.isGrounded)
        {
            Deplacements.y -= gravity * Time.deltaTime;
        }
        charactercontroller.Move(Deplacements * Time.deltaTime);


        //------------------ROTATION JOUEUR ENTIER------------------------//

        rotationx += -Input.GetAxis("Mouse Y") * sensivity;

        rotationx = Mathf.Clamp(rotationx, -LimitRotation, LimitRotation);

        HeadPlayer.transform.localRotation = Quaternion.Euler(rotationx, 0, 0);

        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * sensivity, 0);

        //---ALLER-A-LA-ZONE---//

        //---TIR---//

        timerShoot -= Time.deltaTime;

        if (Input.GetButton("Shoot") && timerShoot <= 0)
        {
            GetComponent<AmmowScript>().Currentammow -= 1;
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
            {
                EnemiesBT cible = hit.collider.GetComponent<EnemiesBT>();

                if (cible != null)
                {
                    cible.GetComponent<CibleScript>().Hit(10);
                }
            }
            
            timerShoot = 0.1f;
        }
        

        if(timerShoot <= 0)
        {
            timerShoot = 0;
        }

    }

}

