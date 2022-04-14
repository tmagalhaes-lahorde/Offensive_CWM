using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class AttackTarget : Nodes
{
    private Transform _transform;
    private Camera _camera;
    private Animator _animator;
    private GameObject[] users;
    private Transform _player;
    private int nbHealth;
    private float timer = 0.1f;
    private float timershoot = 0.1f;

    private AudioSource _shootEnnemieSource;
    private AudioClip _shootEnnemieClip;

    bool isInit = false;

    public AttackTarget(Transform transform, Animator animator, AudioSource shootEnnemieSource, AudioClip shootEnnemieClip)
    {
        _shootEnnemieSource = shootEnnemieSource;
        _shootEnnemieClip = shootEnnemieClip;
        _transform = transform;
        _animator = animator;
    }

    public override NodesState Evaluate()
    {
        if (!isInit)
        {
            users = GameObject.FindGameObjectsWithTag("User");
            isInit = true;
        }

        object t = GetData("target");
        Transform target = (Transform)t;

        if (target == null)
            return NodesState.FAILURE;

        GameObject user = target.gameObject;

            if (user.gameObject != _transform.gameObject)
            {
                Vector3 originPos = new Vector3(_transform.position.x, _transform.position.y + 1, _transform.position.z);
                Vector3 userPos = new Vector3(user.transform.position.x, user.transform.position.y + 1, user.transform.position.z);

                //Vector3 randDir = Random.insideUnitSphere * 2;
                Vector3 dir = userPos - originPos;
                //Vector3 lastDir = (dir + randDir) /2;

                if (Physics.Raycast(originPos, dir , out RaycastHit hit,100))
                {
                    CibleScript cible = hit.collider.GetComponent<CibleScript>();
                    PVScript playerHealth = hit.collider.GetComponent<PVScript>();

                    timer -= Time.deltaTime;
                    timershoot -= Time.deltaTime;
                    if (timer <= 0 && timershoot <= 0)
                    {
                        _transform.gameObject.GetComponent<AmmoScript>().nbAmmo -= 1;

                        _shootEnnemieSource.PlayOneShot(_shootEnnemieClip);

                        //---ANIMATIONS---//
                        _animator.SetBool("Shoot", true);
                        _animator.SetBool("Walk", false);
                        _animator.SetBool("Run", false);

                        //---PLUS-DE-MUNITIONS---//
                        if (_transform.gameObject.GetComponent<AmmoScript>().nbAmmo <= 0)
                        {
                            _transform.gameObject.GetComponent<AmmoScript>().nbAmmo = 0;
                            return NodesState.FAILURE;
                        }
                    if (hit.collider.CompareTag("User"))
                    {
                        if (hit.collider.GetComponent<CibleScript>())
                        {
                            user.GetComponent<CibleScript>().nbHealth -= 5;
                            if (user.GetComponent<CibleScript>().nbHealth <= 0)
                                ClearData("target");
                        }
                        else if(user.GetComponent<PVScript>())
                        {
                            user.GetComponent<PVScript>().CurrentHealth -= 5;
                            if (user.GetComponent<PVScript>().CurrentHealth <= 0)
                                ClearData("target");
                        }
                    }
                        timer = 0.1f;
                        timershoot = 0.1f;
                    }
                }
            }
        return NodesState.FAILURE;
    }
}
