using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class RandBehaviour : Nodes
{
    private int statement;
    private Transform _transform;
    private GameObject[] users;
    public RandBehaviour(Transform transform)
    {
        _transform = transform;
        users = GameObject.FindGameObjectsWithTag("User");
    }

    public override NodesState Evaluate()
    {
        foreach(GameObject user in users)
        {
            if(user != _transform.gameObject)
            {
                statement = Random.Range(0, 2);
                switch (statement)
                {
                    case 0:
                        return NodesState.SUCCESS;//attaque
                    case 1:
                        return NodesState.FAILURE; //fuite
                    default:
                        break;
                }
            }
        }
        return NodesState.FAILURE;
    }
}
