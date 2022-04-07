using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class RandBehaviour : Nodes
{
    private Transform _transform;
    private Animator _animator;
    private int statement;
    public RandBehaviour(Transform transform, Animator animator)
    {
        _transform = transform;
        _animator = animator;
    }

    public override NodesState Evaluate()
    {
        statement = Random.Range(0, 2);

        switch(statement)
        {
            case 0:
                return NodesState.SUCCESS;//attaque
            case 1:
                return NodesState.FAILURE; //fuite
        }
        return NodesState.FAILURE;
    }
}
