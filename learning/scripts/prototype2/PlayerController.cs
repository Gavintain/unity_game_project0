using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    private float input_xaxis;
    private float input_spacebar;
    private float offset_speed = 30f;
    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        input_xaxis = Input.GetAxis("Horizontal");
        input_spacebar = Input.GetAxis("Jump");

        /*if (input_spacebar > 0.001) {
            projectilePrefab = Resources.Load<GameObject>("Prefabs_resources/Food_Banana_01");
            Instantiate(projectilePrefab,transform.position,Quaternion.identity);

        }*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            projectilePrefab = Resources.Load<GameObject>("Prefabs_resources/Food_Banana_01");
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

        }

        /// 플레이어의 X축 좌표가 경계값을 넘으면, 경계선으로 강제로 위치시키기.
        if (transform.position.x < -10){
            transform.position = Vector3.right * -10 + Vector3.up *  transform.position.y +  Vector3.forward *  transform.position.z;
        }
        else if  (transform.position.x > 10){
            transform.position = Vector3.right * 10 + Vector3.up *  transform.position.y +  Vector3.forward *  transform.position.z;
        }
        else{
            transform.Translate(offset_speed * Time.deltaTime * Vector3.right * input_xaxis);
        }
    }
}
