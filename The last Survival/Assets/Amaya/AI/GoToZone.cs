using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class GoToZone : Nodes
{
    private Transform _transform;
    private Animator _animator;
    public GoToZone(Transform transform, Animator animator)
    {
        _transform = transform;
        _animator = animator;
    }

    public override NodesState Evaluate()
    {
        return base.Evaluate();
    }
}
