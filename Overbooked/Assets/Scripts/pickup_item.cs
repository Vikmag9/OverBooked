using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class pickup_item : MonoBehaviour
{

    Ray ray;
    float maxDistance = 10f;
    public LayerMask layerMask;

    private InputAction pickup;

    private PlayerController playerController;

    bool canPickup = true;
    private GameObject pickupHand;

    private GameObject pickedUpItem;

    // Start is called before the first frame update
    void Start()
    {
        pickupHand = GameObject.Find("pickupHand");
    }

    //---------- Pickup action --------------------

    bool CheckForItem()
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
        {
            pickedUpItem = hit.collider.gameObject;
            return true;
        }
        return false;
    }

    void PickupItem(){
        if(canPickup && CheckForItem()){
            Debug.Log("Item picked up");
        }

    }

    //---------- Change position -------------------

    void ChangePosition(GameObject objectHit)
    {
            objectHit.transform.position = pickupHand.transform.position;
            objectHit.GetComponent<Collider>().enabled = false;
            objectHit.GetComponent<Rigidbody>().useGravity = false;
    }

    void FixedUpdate() {
        if(pickedUpItem != null){
            ChangePosition(pickedUpItem);
        }
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.forward);
        ray = new Ray(transform.position, transform.forward);
        //CheckForItem();
    }

     private void Awake()
    {
        playerController = new PlayerController();
    }
    private void OnEnable()
    {
        pickup = playerController.Player.Pickup;

        pickup.Enable();

        pickup.performed += ctx => PickupItem();
    }

    private void OnDisable()
    {
        pickup.Disable();
    }
}
