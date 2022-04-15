using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;
public class FOVAmmo : Nodes
{
    private Transform _transform;
    private Animator _animator;

    GameObject[] ammobox;
    private bool isInit = false;
    public FOVAmmo(Transform transform, Animator animator)
    {
        _transform = transform;
        _animator = animator;

    }
    public override NodesState Evaluate()
    {
        if (_transform.gameObject.GetComponent<AmmoScript>().nbAmmo > 50)
        {
            return NodesState.FAILURE;
        }

        if (!isInit)
        {
            ammobox = GameObject.FindGameObjectsWithTag("Ammow");
            isInit = true;
        }

        ClearData("Ammow");

        foreach (GameObject ammow in ammobox)
        {
            if (ammow.activeSelf == true)
            {
                if(_transform.gameObject.GetComponent<AmmoScript>().nbAmmo <= 50)
                {
                    if (Vector3.Distance(ammow.transform.position, _transform.position) < 10)
                    {
                        Vector3 dir = ammow.transform.position - _transform.position;
                        float angle = Vector3.Angle(dir, _transform.forward);

                        if (angle < 60)
                        {
                            SetData("Ammow", ammow.transform);
                            _transform.LookAt(ammow.transform.position);
                            return NodesState.SUCCESS;
                        }
                    }
                }
                
            }
        }
        return NodesState.FAILURE;
    }
}
