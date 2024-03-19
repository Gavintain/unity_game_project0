using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // public GameObject animalPrefabsCow ;
    // public GameObject animalPrefabsHorse ;
    // public GameObject animalPrefabsDog ;
    // public GameObject[] animalPrefabs;
    // // Start is called before the first frame update
    // void Awake(){
    //     animalPrefabsCow = Resources.Load<GameObject>("Prefabs_resources/Animal_Cow_White");
    //     animalPrefabsHorse = Resources.Load<GameObject>("Prefabs_resources/Animal_Horse_Black");
    //     animalPrefabsDog = Resources.Load<GameObject>("Prefabs_resources/Dog_Beagle_01");
    //     animalPrefabs = new GameObject[]{animalPrefabsCow,animalPrefabsHorse,animalPrefabsDog};
        
    // }
    public GameObject[] animalPrefabs = new GameObject[3];
    private int spawnXrange = 10;
    private float spawnZposition = 28f;
    private float spawnStartTime = 1f;
    private float spawnIntervalTime = 1f;
    void Start()
    {
        InvokeRepeating("SpawnAnimalRepeativly",spawnStartTime,spawnIntervalTime);
    }

    // Update is called once per frame
    void Update(){

    }
    void SpawnAnimalRepeativly()
    {
        int randomIndex = Random.Range(0,3);
        int randomXaxis = Random.Range(-spawnXrange,spawnXrange);
        Instantiate(animalPrefabs[randomIndex],new Vector3(randomXaxis,0,spawnZposition),animalPrefabs[randomIndex].transform.rotation);
        
    }
}
