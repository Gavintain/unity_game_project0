using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab; 
    public float reloadingTime = 2.5f;
    private bool dogReload = true;
    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space)&(dogReload))
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            dogReload = false;
            Invoke("DogReloading",reloadingTime);
        }
        
    }
    void DogReloading()
    {
        dogReload = true;
    }
}
