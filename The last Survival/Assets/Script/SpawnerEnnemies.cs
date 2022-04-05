using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        while(EnnemiesCount < 99)
        {
            Xpos = Random.Range(1, 1001);
            Zpos = Random.Range(1, 1001);
            Instantiate(ennemy, new Vector3(Xpos, 1, Zpos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            EnnemiesCount += 1;
        }
    }
}
