using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Camera HeadPlayer;
    public CharacterController charactercontroller;

    private Vector3 Deplacements;

    public bool Grounded;
    private bool Running = false;

    public float LimitRotation = 30.0f,sensivity = 10.0f, angle, rotationx = 0,Health = 100;

    private float maxHealth = 100,runningSpeed = 30f, walkingSpeed = 15f,gravity = 9, jumpForce =5;

    private void Start()
    {
        charactercontroller = GetComponent<CharacterController>();
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
            Debug.Log("outground");
            Deplacements.y -= gravity * Time.deltaTime;
        }
        charactercontroller.Move(Deplacements * Time.deltaTime); //permet un déplacement lisse sans acoups


        //------------------ROTATION JOUEUR ENTIER------------------------//

        rotationx += -Input.GetAxis("Mouse Y") * sensivity;

        rotationx = Mathf.Clamp(rotationx, -LimitRotation, LimitRotation);

        HeadPlayer.transform.localRotation = Quaternion.Euler(rotationx, 0, 0);

        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * sensivity, 0);
    }

    public void Hit(float dmg)
    {
        Health -= dmg;

        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

