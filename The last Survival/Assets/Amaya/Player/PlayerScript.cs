using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Transform arrowPointer;
    public Transform targetCenterZone;
    public Camera HeadPlayer;
    public CharacterController charactercontroller;
    public LineRenderer goToZone;

    public AudioSource jumpSource;
    public AudioClip jumpClip;
    public AudioSource shootSource;
    public AudioClip shootClip;







    private Vector3 Deplacements;
    public Zone inZone;
    private PVScript Health;

    public bool Grounded, Running;

    private int nbAmmo;
    public float LimitRotation = 30.0f, sensivity = 0.01f, angle, rotationx = 0, timerShoot = 0.1f;

    private float runningSpeed = 30f, walkingSpeed = 15f, gravity = 9, jumpForce = 5;

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

        if (Input.GetButton("Run"))
            Running = true;
        else Running = false;


        if (Running == true)
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
            jumpSource.PlayOneShot(jumpClip);
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
       





        //------------------ROTATION JOUEUR ENTIER (SOURIS)------------------------//

        rotationx += -Input.GetAxis("Mouse Y") * sensivity;

        rotationx = Mathf.Clamp(rotationx, -LimitRotation, LimitRotation);

        HeadPlayer.transform.localRotation = Quaternion.Euler(rotationx, 0, 0);

        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * sensivity, 0);


        rotationx += -Input.GetAxis("Joy RY") * 1;

        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Joy RX") * 1, 0);

        //---ALLER-A-LA-ZONE---//


        //---TIR (CLAVIER)---//

        timerShoot -= Time.deltaTime;

        if (Input.GetButton("Shoot") && timerShoot <= 0)
        {
            GetComponent<AmmowScript>().Currentammow -= 1;
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
            {
                EnemiesBT cible = hit.collider.GetComponent<EnemiesBT>();
                shootSource.PlayOneShot(shootClip);

                if (cible != null)
                {
                    cible.GetComponent<CibleScript>().Hit(10);
                }

            }

            timerShoot = 0.1f;
        }

        //---TIR(MANETTE)---//

        if (Input.GetAxis("Shoot") == 1 && timerShoot <= 0)
        {
            GetComponent<AmmowScript>().Currentammow -= 1;
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
            {
                EnemiesBT cible = hit.collider.GetComponent<EnemiesBT>();
                shootSource.PlayOneShot(shootClip);

                if (cible != null)
                {
                    cible.GetComponent<CibleScript>().Hit(10);
                }
            }

            timerShoot = 0.1f;
        }



        if (timerShoot <= 0)
        {
            timerShoot = 0;
        }

    }
    

}

