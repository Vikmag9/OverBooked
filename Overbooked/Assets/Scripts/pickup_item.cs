using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class pickup_item : MonoBehaviour
{

    public LayerMask layerMask;

    bool holding = false;
    private bool inRangeOfItem = false;
    bool canPickup = true;

    private PlayerController playerController;
    private InputAction pickup;

    private GameObject pickupHand;
    private GameObject pickedUpItem;
    

    // Start is called before the first frame update
    void Start()
    {
        pickupHand = GameObject.Find("pickupHand");
        EventManager.current.questDeactive += DropItem;

    }

    //---------- Change position -------------------

    void ChangePosition(GameObject objectHit)
    {
            objectHit.transform.position = pickupHand.transform.position;
            objectHit.GetComponent<Collider>().enabled = false;
            objectHit.GetComponent<Rigidbody>().useGravity = false;
            
    }

    void DropItem()
    {
        Debug.Log("Drop Item");
            pickedUpItem.GetComponent<Collider>().enabled = true;
            pickedUpItem.GetComponent<Rigidbody>().useGravity = true;
            pickedUpItem = null;
            canPickup = true;
            holding = false;
            
            EventManager.current.DroppedItem();

            
        
    }

    //---------- Update ---------------------------

    void FixedUpdate() {
        if(pickedUpItem != null && holding){
            ChangePosition(pickedUpItem);
            
        }
    }


    // Update is called once per frame
    void Update()
    {

        if (canPickup && inRangeOfItem)
        {
            pickup.performed += checkKeypress;
            
        }

    }

     private void Awake()
    {
        playerController = new PlayerController();
    }
    private void OnEnable()
    {
        pickup = playerController.Player.Pickup;
        pickup.Enable();

    }

    private void OnDisable()
    {
        pickup.Disable();
    }

    void checkKeypress(InputAction.CallbackContext context){
        if(!holding){
            PickUpItem();
        }
        else{
            DropItem();
        }
    }

    

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pickupable") && canPickup == true)
        {
            pickup.Enable();
        
            pickedUpItem = other.gameObject;
            inRangeOfItem = true;
        }
        

    }

    private void PickUpItem()
    {
        
            canPickup = false;
            holding = true;
            if (pickedUpItem.CompareTag("Cleaning"))
            {
                EventManager.current.PickedUpCleaningItem();
            }
            else if (pickedUpItem.CompareTag("Roomservic"))
            {
                EventManager.current.PickedUpRoomservicItem();
            }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pickupable") && canPickup == true)
        {
            pickup.Disable();
            pickedUpItem = null;
            inRangeOfItem = false;
            holding = false;
        }
        
    }
}
