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
        List<GameObject> ennemis = new List<GameObject>();

        for(int i = 0; i < users.Length; i++)
        {
            ennemis.Add(users[i].gameObject);
        }

        foreach (GameObject user in ennemis)
        {
            if (user != _transform.gameObject)
            {
                if (Vector3.Distance(user.transform.position, _transform.position) < 10)
                {
                    Vector3 dir = user.transform.position - _transform.position;
                    float angle = Vector3.Angle(dir, _transform.forward);

                    if (angle < 60)
                    {
                        _transform.LookAt(user.transform.position);
                        return NodesState.SUCCESS;
                    }
                }
            }
        }
        return NodesState.FAILURE;
    }
}