using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree;
public class FOVAmmo : Nodes
{
    private Transform _transform;
    private Animator _animator;

    GameObject[] ammobox;
    public FOVAmmo(Transform transform, Animator animator)
    {
        _transform = transform;
        _animator = animator;
        ammobox = GameObject.FindGameObjectsWithTag("Ammow");

    }
    public override NodesState Evaluate()
    {
        List<GameObject> ammo = new List<GameObject>();

        for (int i = 0; i < ammobox.Length; i++)
        {
            ammo.Add(ammobox[i].gameObject);
        }

        foreach (GameObject ammow in ammo)
        {
            if (ammow.activeSelf == true)
            {
                if (Vector3.Distance(ammow.transform.position, _transform.position) < 10)
                {
                    Vector3 dir = ammow.transform.position - _transform.position;
                    float angle = Vector3.Angle(dir, _transform.forward);

                    if (angle < 60)
                    {
                        _transform.LookAt(ammow.transform.position);
                        return NodesState.SUCCESS;
                    }
                }
            }
        }
        return NodesState.FAILURE;
    }
}
