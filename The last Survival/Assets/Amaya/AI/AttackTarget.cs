using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class AttackTarget : Nodes
{
    private Transform _transform;
    private Animator _animator;
    private GameObject[] _users;
    private PVScript[] healthUser;
    private float shootingTime = 1f;

    private int nbShot = 0;
    public AttackTarget(Transform transform, Animator animator)
    {
        _transform = transform;
        _animator = animator;
    }

    public override NodesState Evaluate()
    {
        Transform target = (Transform)GetData("target");

        if (Vector3.Distance(_transform.position, target.position) < 3f)
        {
            shootingTime -= Time.deltaTime;
            Debug.Log("BetterShoot");

            if (shootingTime <= 0)
            {
                nbShot += 1;
                shootingTime = 1f;
            }

            if(nbShot >= 5)
            {
                return NodesState.SUCCESS;
            }
            return NodesState.RUNNING;
        }
        return NodesState.FAILURE;
    }
}
