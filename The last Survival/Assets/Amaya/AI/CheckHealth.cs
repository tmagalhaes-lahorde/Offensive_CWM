using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class CheckHealth : Nodes
{
    private Transform _transform;
    private Animator _animator;

    public CheckHealth(Transform transform, Animator animator)
    {
        _transform = transform;
        _animator = animator;
    }

    public override NodesState Evaluate()
    {
        if(_transform.gameObject.GetComponent<CibleScript>().nbHealth>=60)

        {
            return NodesState.SUCCESS;
        }
        return NodesState.FAILURE;
    }
}
