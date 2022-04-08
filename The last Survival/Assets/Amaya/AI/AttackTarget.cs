using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class AttackTarget : Nodes
{
    private Transform _transform;
    private Animator _animator;
    private GameObject[] users;
    private int nbAmmo = 20;
    private int nbHealth = 100;
    private float timer = 0.1f;

    private int nbShot = 0;
    public AttackTarget(Transform transform, Animator animator)
    {
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
                Vector3 dir = user.transform.position - _transform.position;
                float angle = Vector3.Angle(dir, _transform.forward);

                timer -= Time.deltaTime;
                if(timer <= 0)
                {
                    nbAmmo -= 1;
                    Debug.Log("LESSSGOOOOOOOOOOOOO");
                    _animator.SetBool("Shoot", true);
                    _animator.SetBool("Walk", false);
                    _animator.SetBool("Run", false);
                    //add damage to user ennemi !

                    if (nbAmmo <= 0)
                    {
                        nbAmmo = 0;
                        return NodesState.FAILURE;
                    }

                    if (nbHealth <= nbHealth / 2)
                    {
                        if(nbHealth <= 0)
                        {
                            nbHealth = 0;
                            _transform.gameObject.SetActive(false);
                        }
                        return NodesState.FAILURE;
                    }
                    timer = 0.1f;
                }
                return NodesState.RUNNING;
            }
        }
        return NodesState.FAILURE;
    }
}
