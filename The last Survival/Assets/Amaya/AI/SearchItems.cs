using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviourTree;
public class SearchItems : Nodes
{
    private Transform _transform;
    private Animator _animator;
    private GameObject[] medikits;
    private GameObject[] ammobox;
    private NavMeshAgent _agent;
    public SearchItems(Transform transform, Animator animator, NavMeshAgent agent)
    {
        _transform = transform;
        _animator = animator;
        _agent = agent;
    }

    public override NodesState Evaluate()
    {
        object k = GetData("HealthKit");
        object a = GetData("Ammow");

        Transform kit = (Transform)k;
        Transform ammo = (Transform)a;

        if (kit != null)
        {
            _agent.SetDestination(kit.transform.position);
            return NodesState.SUCCESS;
        }

        if (ammo != null)
        {
            _agent.SetDestination(ammo.transform.position);
            return NodesState.SUCCESS;
        }

        return NodesState.FAILURE;
    }
    
}
