using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviourTree;

public class GoToZone : Nodes
{
    private Zone _zone;
    private Transform _transform;
    private Animator _animator;
    private NavMeshAgent _waypointFollow;
    private NavMeshAgent _agent;
    public GoToZone(Transform transform, Animator animator,NavMeshAgent agent, NavMeshAgent wpFollow,Zone zone)
    {
        _transform = transform;
        _animator = animator;
        _agent = agent;
        _waypointFollow = wpFollow;
        _zone = zone;
    }

    public override NodesState Evaluate()
    {
        _transform.GetComponent<CibleScript>();

        if (_transform.gameObject.GetComponent<CibleScript>().outZone)
        {
            _waypointFollow.SetDestination(_zone.centerZone);
            _agent.SetDestination(_waypointFollow.transform.position);
            return NodesState.SUCCESS;

        }
        return NodesState.FAILURE;
    }
}
