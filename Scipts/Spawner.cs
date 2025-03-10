using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] akadalyMintak;
    private float idosk;
    public float kezdesSpawnIdo;
    public float csokIdo;
    public float minIdo;

    void Update()
    {
        if (idosk <= 0)
        {
            int rand = Random.Range(0, akadalyMintak.Length);
            Instantiate(akadalyMintak[rand], transform.position, Quaternion.identity);
            idosk = kezdesSpawnIdo;
            if (kezdesSpawnIdo > minIdo)
            {
                idosk -= csokIdo;
            }
        }
        else
        {
            idosk -= Time.deltaTime;
        }
    }
}
