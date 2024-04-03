using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float groundBound = 13f;
    public GameObject[] enemyPrefabs;
    void Start()
    {
        InvokeRepeating("spawning",1f,1f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void spawning(){
        Vector3 spawnPos = new Vector3(Random.Range(-groundBound,groundBound),0,Random.Range(-groundBound,groundBound));
        Instantiate(enemyPrefabs[0],spawnPos,transform.rotation);
    }
}
