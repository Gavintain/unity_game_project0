using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] obstacles;
    void Start()
    {
        InvokeRepeating("Spawning",2f,3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawning(){
        Vector3 spawnPos = new Vector3(25,1,1);
        GameObject obstacle = obstacles[0];
        Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
    }
}
