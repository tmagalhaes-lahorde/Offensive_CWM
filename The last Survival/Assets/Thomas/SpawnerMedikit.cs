using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMedikit : MonoBehaviour
{
    public GameObject ennemy;
    public Transform rotationX;
    public int Xpos;
    public int Zpos;
    public int Medikitcount;

    void Start()
    {
        StartCoroutine(MedikitCount());
    }

    IEnumerator MedikitCount()
    {
        while ( Medikitcount < 30)
        {
            Xpos = Random.Range(0, 100);
            Zpos = Random.Range(0, 100);
            Instantiate(ennemy, new Vector3(Xpos, 0, Zpos), Quaternion.identity);
            yield return new WaitForSeconds(0f);
            Medikitcount += 1;
        }
    }
}

