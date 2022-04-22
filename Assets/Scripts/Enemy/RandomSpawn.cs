using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] enemies;
    public float timeBetweenWaves;
    public int noInWave;
    public int minRad;
    public int maxRad;

    //Fix this later
    public GameObject core;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 5, timeBetweenWaves);   
    }

    void Spawn()
    {
        for (int i = 0; i < noInWave; i++)
        {
            Vector3 offset = Random.insideUnitCircle.normalized * Random.Range(minRad, maxRad);
            Instantiate(enemies[0], offset, Quaternion.identity);
        }
    }
}
