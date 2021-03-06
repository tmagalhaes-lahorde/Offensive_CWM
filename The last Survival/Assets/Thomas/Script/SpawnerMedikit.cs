using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMedikit : MonoBehaviour
{
    public GameObject medikit;
    public int Xpos;
    public int Zpos;
    public int Medikitcount;

    void Start()
    {
        StartCoroutine(MedikitCount());
    }

    IEnumerator MedikitCount()
    {
        while ( Medikitcount < 200)
        {
            Xpos = Random.Range(-501, 470);
            Zpos = Random.Range(-501, 470);
            Instantiate(medikit, new Vector3(Xpos, 50, Zpos), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            Medikitcount += 1;
        }
    }
}