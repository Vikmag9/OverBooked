using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class pedestrianSpawner : MonoBehaviour
{
    public GameObject spawnerObject;
    public GameObject spawnPosObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Random rnd = new Random();
        int num = rnd.Next(1000);

        Vector3 spawnPos = spawnPosObj.transform.position;


        if(num == 1){
            Instantiate(spawnerObject, spawnPos, Quaternion.identity);
        }
    }
}
