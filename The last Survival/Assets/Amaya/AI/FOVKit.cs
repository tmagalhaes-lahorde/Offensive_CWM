using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;

public class FOVKit : Nodes
{
    private Transform _transform;
    private Animator _animator;
   
    GameObject[] medikits;
    public FOVKit(Transform transform, Animator animator)
    {
        _transform = transform;
        _animator = animator;
        medikits = GameObject.FindGameObjectsWithTag("HealthKit");

    }
    public override NodesState Evaluate()
    {
        List<GameObject> kits = new List<GameObject>();

        for (int i = 0; i < medikits.Length; i++)
        {
            kits.Add(medikits[i].gameObject);
        }

        foreach (GameObject kit in kits)
        {
            if (kit.activeSelf == true)
            {
                if (Vector3.Distance(kit.transform.position, _transform.position) < 10)
                {
                    Vector3 dir = kit.transform.position - _transform.position;
                    float angle = Vector3.Angle(dir, _transform.forward);

                    if (angle < 60)
                    {
                        _transform.LookAt(kit.transform.position);
                        return NodesState.SUCCESS;
                    }
                }
            }
        }
        return NodesState.FAILURE;
    }
}
