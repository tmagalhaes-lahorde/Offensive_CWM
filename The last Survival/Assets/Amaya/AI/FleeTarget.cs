using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviourTree;

public class FleeTarget : Nodes
{
    private Transform _transform;
    private Animator _animator;
    private NavMeshAgent _agent;
    private GameObject[] users;
    public FleeTarget(Transform transform, Animator animator,NavMeshAgent agent)
    {
        _transform = transform;
        _animator = animator;
        _agent = agent;
        users = GameObject.FindGameObjectsWithTag("User");
    }

    public override NodesState Evaluate()
    {
        foreach(GameObject user in users)
        {
            Vector3 dir = _transform.position - user.transform.position;
            Vector3 NextPos = _transform.position + dir * 2;
            _agent.SetDestination(NextPos);
            return NodesState.SUCCESS;
        }
        return NodesState.FAILURE;
    }
}
