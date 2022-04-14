using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class FOVKit : Nodes
{
    private Transform _transform;
    private Animator _animator;
   
    GameObject[] medikits;
    private bool isInit = false;
    public FOVKit(Transform transform, Animator animator)
    {
        _transform = transform;
        _animator = animator;

    }
    public override NodesState Evaluate()
    {
        if (_transform.gameObject.GetComponent<CibleScript>().nbHealth > 30)
        {
            return NodesState.FAILURE;
        }

        if(!isInit)
        {
            medikits = GameObject.FindGameObjectsWithTag("HealthKit");
            isInit = true;
        }

        ClearData("HealthKit");

        foreach (GameObject kit in medikits)
        {
            if (kit.activeSelf == true)
            {
                if(_transform.gameObject.GetComponent<CibleScript>().nbHealth <= 50)
                {
                    if (Vector3.Distance(kit.transform.position, _transform.position) < 10)
                    {
                        Vector3 dir = kit.transform.position - _transform.position;
                        float angle = Vector3.Angle(dir, _transform.forward);

                        if (angle < 60)
                        {
                            SetData("HealthKit", kit.transform);
                            _transform.LookAt(kit.transform.position);
                            return NodesState.SUCCESS;
                        }
                    }
                }
            }
        }
        return NodesState.FAILURE;
    }
}
