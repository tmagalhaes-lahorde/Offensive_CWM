using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class CheckAmmo : Nodes
{
    private Transform _transform;
    private Animator _animator;

    public CheckAmmo(Transform transform, Animator animator)
    {
        _transform = transform;
        _animator = animator;
    }

    public override NodesState Evaluate()
    {
        if(_transform.gameObject.GetComponent<AmmoScript>().nbAmmo>=50)
        {
            return NodesState.SUCCESS;
        }
        return NodesState.FAILURE;
    }
}
