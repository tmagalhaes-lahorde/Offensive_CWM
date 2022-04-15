using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAmmow : MonoBehaviour
{
    public GameObject Ammow;
    public int Xpos;
    public int Zpos;
    public int ammow;

    void Start()
    {
        StartCoroutine(ammowCount());
    }

    IEnumerator ammowCount()
    {
        while (ammow < 200)
        {
            Xpos = Random.Range(-501, 470);
            Zpos = Random.Range(-501, 470);
            Instantiate(Ammow, new Vector3(Xpos, 50, Zpos), Quaternion.identity);
            yield return new WaitForSeconds(2);
            ammow += 1;
        }
    }
}