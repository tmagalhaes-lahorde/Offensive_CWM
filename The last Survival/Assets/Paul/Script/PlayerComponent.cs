using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent : MonoBehaviour

   
{
    //Cam�ra de mon player
    public Camera playercamera;

    //Initialise mon composant character controller
    CharacterController charactercontroller;

    //Initialise ma valeur de marche
    public float walkingSpeed = 7.5f;

    //Initialise ma valeur de course
    public float runningSpeed = 150.0f;

    //Initialiser ma valeur de saut
    public float jumpSpeed = 8.0f;

    //Initialise ma valeur de gravit�
    float gravity = 20.0f;

    //Cr�e un vecteur de d�placement sur x,y,z
    Vector3 moveDirection;

    //Marche ou course ?
    bool isRunning = false;

    //Rotation de la cam�ra
    float rotationX = 0.0f;
    public float rotationSpeed = 2.0f;
    public float rotationXlimit = 45.0f;




    // Start is called before the first frame update
    void Start()
    {
        //Permets de cacher le curseur de la souris
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        charactercontroller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //forward = avant/arri�re
        //right = gauche/droite
        //Cr�� deux vecteurs de direction pour le player
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        //R�cup�re l'input pour Z
        float speedZ = Input.GetAxis("Vertical");

        //R�cup�re l'input pour X
        float speedX = Input.GetAxis("Horizontal");

        //Donne une direction pour Y
        float speedY = moveDirection.y;

        //Si j'appuie sur left shift on passe le boll�en � true pour la course.
        if(Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }

           else
        {
            isRunning = false;
        }

        //D�finie ma vitesse en course
        if(isRunning)
        {
            speedX = speedX * runningSpeed;
            speedZ = speedZ * runningSpeed;

        }

        //D�finie ma vitesse en marche

        else
        {
            speedX = speedX * walkingSpeed;
            speedZ = speedZ * walkingSpeed;
        }

        //Calcul du mouvement
        //Forward = avant/arri�re
        //Right = axe gauche ou droite
        moveDirection = forward * speedZ + right * speedX;

        //D�finie ma direction du saut avec une valeur si le player et en collision avec le sol et qu'on appuie sur l'input de jump
        if(Input.GetButton("Jump")&&charactercontroller.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }

        //Sinon elle reste � 0
        else
        {
            moveDirection.y = speedY;
        }

        // Si le player n'est pas au sol on applique la gravit�
        if(!charactercontroller.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        charactercontroller.Move(moveDirection * Time.deltaTime);

        // D�finie l'axe de rotation de la cam�ra
        rotationX += -Input.GetAxis("Mouse Y") * rotationSpeed;

        rotationX = Mathf.Clamp(rotationX, -rotationXlimit, rotationXlimit);

        playercamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * rotationSpeed, 0);
    }
}
