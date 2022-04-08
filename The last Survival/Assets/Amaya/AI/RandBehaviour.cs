using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class RandBehaviour : Nodes
{
    private int statement;
    public RandBehaviour()
    {
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
            default:
                break;
        }
        return NodesState.FAILURE;
    }
}
