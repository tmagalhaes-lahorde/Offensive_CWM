using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using BehaviourTree;

public class FieldOfView : Nodes
{
    private Transform _transform;
    private Animator _animator;
    public FieldOfView(Transform transform, Animator animator)
    {
        _transform = transform;
        _animator = animator;
    }

    public override NodesState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            Collider[] colliders = Physics.OverlapSphere(
                _transform.position, EnemiesBT.fovRange , 8);

            colliders.OrderBy(hit => Vector3.Distance(hit.transform.position, _transform.position));
            Debug.Log(colliders.Length);

            if (colliders.Length > 0)
            {
                Parents.Parents.SetData("target", colliders[0].transform);
                state = NodesState.SUCCESS;
                return state;
            }
            state = NodesState.FAILURE;
            return state;
        }
        state = NodesState.SUCCESS;
        return state;
    }
}
