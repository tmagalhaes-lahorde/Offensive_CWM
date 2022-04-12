using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SearchGround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(transform.position, out hit, 100.0f, NavMesh.AllAreas))
        {
            transform.position = hit.position;
        }
    }
}
