using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using UnityEngine.InputSystem;

public class pedestrianSpawner : MonoBehaviour
{
    public PlayerController playerController;
    private InputAction spawn;
    public GameObject spawnerObject;
    public GameObject spawnPosObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        playerController = new PlayerController();
    }

        private void OnEnable()
    {
        spawn = playerController.Player.Testspawner;

        spawn.Enable();

        spawn.performed += Testspawner;
    }

    private void OnDisable()
    {
        spawn.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        Random rnd = new Random();
        int num = rnd.Next(1000);

        Vector3 spawnPos = spawnPosObj.transform.position;


        if(num == 1){
            GameObject newObject = Instantiate(spawnerObject, spawnPos, Quaternion.identity);
            //newObject.transform.localScale = new Vector3(0.08558407f,0.8690293f,0.02937347f);
            newObject.transform.localScale = new Vector3(1f,1f,1f);
        }
    }

        void Testspawner(InputAction.CallbackContext contex)
    {
            Vector3 spawnPos = spawnPosObj.transform.position;

            GameObject newObject = Instantiate(spawnerObject, spawnPos, Quaternion.identity);
            //newObject.transform.localScale = new Vector3(0.08558407f,0.8690293f,0.02937347f);
            newObject.transform.localScale = new Vector3(1f,1f,1f);
            newObject.transform.Rotate(1f, -90f, 1f);
    }
}
