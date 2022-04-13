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
    private NavMeshAgent _agent;
    public SearchItems(Transform transform, Animator animator)
    {
        _transform = transform;
        _animator = animator;
        medikits = GameObject.FindGameObjectsWithTag("HealthKit");
    }

    public override NodesState Evaluate()
    {
        foreach(GameObject kit in medikits)
        {
            _agent.SetDestination(kit.transform.position);
            return NodesState.FAILURE;
        }
        return NodesState.SUCCESS;
    }
}
