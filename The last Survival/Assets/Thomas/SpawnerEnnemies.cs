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
            Xpos = Random.Range(-499, 499);
            Zpos = Random.Range(-499, 499);
            Instantiate(ennemy, new Vector3(Xpos, 100, Zpos), Quaternion.identity);
            yield return new WaitForSeconds(0f);
            EnnemiesCount += 1;

            if (EnnemiesCount >= 99)
            {
                break;
            }
        }
    }
}
