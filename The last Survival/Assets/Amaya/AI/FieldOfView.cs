using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using BehaviourTree;

public class FieldOfView : Nodes
{
    private Transform _transform;
    private Animator _animator;
    private static LayerMask _enemyLayerMask = 1 << 8;
    GameObject[] users;
    public FieldOfView(Transform transform, Animator animator)
    {
        _transform = transform;
        _animator = animator;
        users = GameObject.FindGameObjectsWithTag("User");
    }
    public override NodesState Evaluate()
    {
        //object t = GetData("target");
        //if (t == null)
        //{
        //    Collider[] colliders = Physics.OverlapSphere(
        //        _transform.position, EnemiesBT.fovRange, _enemyLayerMask);

        //    //colliders.OrderBy(hit => Vector3.Distance(hit.transform.position, _transform.position));

        //    if (colliders.Length > 0)
        //    {
        //        Parents.Parents.SetData("target", colliders[0].transform);
        //        state = NodesState.SUCCESS;
        //        return state;
        //    }
        //    state = NodesState.FAILURE;
        //    return state;
        //}
        //state = NodesState.SUCCESS;
        //return state;

        foreach(GameObject user in users)
        {
            if (user != _transform.gameObject)
            {
                if (Vector3.Distance(user.transform.position, _transform.position) < 5)
                {
                    Vector3 dir = user.transform.position - _transform.position;
                    float angle = Vector3.Angle(dir, _transform.forward);

                    if (angle < 60)
                    {
                        Debug.Log("coucou");
                    }
                }
            }
            
        }
        return NodesState.FAILURE;
    }
}