using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnerEnnemies : MonoBehaviour
{
    public GameObject ennemy;
    public int Xpos;
    public int Zpos;
    public int EnnemiesCount;

    void Start()
    {
        StartCoroutine(EnnemyDrop());
    }

    IEnumerator EnnemyDrop()
    {
        while(EnnemiesCount < 98)
        {
            Xpos = Random.Range(-501, 499);
            Zpos = Random.Range(-501, 473);

            NavMeshHit hit;
            while (!NavMesh.SamplePosition(new Vector3(Xpos, 50, Zpos), out hit, 100.0f, NavMesh.AllAreas));

            Instantiate(ennemy, hit.position, Quaternion.identity);

            yield return new WaitForSeconds(0f);
            EnnemiesCount += 1;

            if (EnnemiesCount >= 98)
            {
                break;
            }
        }
    }
}
