using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class FleeTarget : Nodes
{
    private Transform _transform;
    private Animator _animator;
    public FleeTarget(Transform transform, Animator animator)
    {
        _transform = transform;
        _animator = animator;
    }

    public override NodesState Evaluate()
    {
        return NodesState.SUCCESS;
    }
}
