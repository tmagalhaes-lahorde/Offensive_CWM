using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using BehaviourTree;

public class FieldOfView : Nodes
{
    private Transform _transform;
    private Transform _player;
    private Animator _animator;
    private static LayerMask _enemyLayerMask = 1 << 8;
    private bool isInit = false;

    GameObject[] users;
    public FieldOfView(Transform transform,Animator animator)
    {
        _transform = transform;
        _animator = animator;
    }
    public override NodesState Evaluate()
    {
        if (!isInit)
        {
            users = GameObject.FindGameObjectsWithTag("User");
            isInit = true;
        }
        ClearData("target");

        foreach (GameObject user in users)
        {
            if (user != _transform.gameObject)
            {
                if(user.activeSelf == true)
                if (Vector3.Distance(user.transform.position, _transform.position) < 10)
                {
                    Vector3 dir = user.transform.position - _transform.position;
                    float angle = Vector3.Angle(dir, _transform.forward);

                    if (angle < 60)
                    {
                        _transform.LookAt(user.transform.position);
                        SetData("target", user.transform);
                        return NodesState.SUCCESS;
                    }
                }
            }
        }
        return NodesState.FAILURE;
    }
}