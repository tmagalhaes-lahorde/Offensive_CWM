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
    private int nbHealth;
    private float timer = 0.1f;
    private float timershoot = 0.1f;

    private AudioSource _shootEnnemieSource;
    private AudioClip _shootEnnemieClip;

    public AttackTarget(Transform transform, Animator animator, AudioSource shootEnnemieSource, AudioClip shootEnnemieClip)
    {
        _shootEnnemieSource = shootEnnemieSource;
        _shootEnnemieClip = shootEnnemieClip;
        _transform = transform;
        _animator = animator;
        users = GameObject.FindGameObjectsWithTag("User");
    }

    public override NodesState Evaluate()
    {
        foreach(GameObject user in users)
        {
            if (user.gameObject != _transform.gameObject)
            {

                Vector3 randDir = Random.insideUnitSphere * 2;
                Vector3 dir = user.transform.position - _transform.position;
                Vector3 lastDir = (dir + randDir) /2;

                

                if (Physics.Raycast(_transform.position,lastDir, out RaycastHit hit,10))
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

                        if(cible != null)
                        {
                            cible.Hit(10);
                        }

                        if(playerHealth != null)
                        {
                            playerHealth.DamageButton(10);
                        }

                        timer = 0.1f;
                        timershoot = 0.1f;
                    }
                }
                return NodesState.RUNNING;
            }
        }
        return NodesState.FAILURE;
    }
}
