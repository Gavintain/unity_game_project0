using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float groundBound = 11f;
    private int waveNum = 1;
    public GameObject[] enemyPrefabs;
    public GameObject[] powerUpPrefabs;
    void Start()
    {
        spawningEnemy(waveNum);
    }

    // Update is called once per frame
    void Update()
    {   
        int enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount<1){
            waveNum+=1;
            spawningEnemy(waveNum);
            spawningPowerUps();
        }
    }

    void spawningEnemy(int waveNumber){
        for(int i=0;i< waveNumber * 3;i++){
            Vector3 spawnPos = new Vector3(Random.Range(-groundBound,groundBound),0,Random.Range(-groundBound,groundBound));
            Instantiate(enemyPrefabs[0],spawnPos,transform.rotation);
        }
    }
    void spawningPowerUps(){
        Vector3 spawnPos = new Vector3(Random.Range(-groundBound,groundBound),0,Random.Range(-groundBound,groundBound));
        Instantiate(powerUpPrefabs[0],spawnPos,transform.rotation);
    }
}
