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
    public GoToZone(Transform transform, Animator animator, NavMeshAgent wpFollow,Zone zone)
    {
        _transform = transform;
        _animator = animator;
        _waypointFollow = wpFollow;
        _zone = zone;
    }

    public override NodesState Evaluate()
    {
        _transform.GetComponent<CibleScript>();

        if(_transform.gameObject.GetComponent<CibleScript>().outZone == true)
        {
            _waypointFollow.transform.position = _zone.centerZone;
        }
        return NodesState.FAILURE;
    }
}
