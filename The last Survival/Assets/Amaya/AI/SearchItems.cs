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
        medikits = GameObject.FindGameObjectsWithTag("HealthKit");
        ammobox = GameObject.FindGameObjectsWithTag("Ammow");
    }

    public override NodesState Evaluate()
    {
        foreach(GameObject kit in medikits)
        {
            _agent.SetDestination(kit.transform.position);
            return NodesState.SUCCESS;
        }

        foreach (GameObject ammo in ammobox)
        {
            _agent.SetDestination(ammo.transform.position);
            return NodesState.SUCCESS;
        }
        return NodesState.FAILURE;
    }
}
