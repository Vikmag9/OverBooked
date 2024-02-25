using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class pickup_item : MonoBehaviour
{

    Ray frontRay;
    Ray leftRay;
    Ray rightRay;
    Ray backRay;

    bool frontRayCast;
    bool leftRayCast;
    bool rightRayCast;
    float maxDistance = 2f;
    public LayerMask layerMask;
    bool holding = false;

    
    private PlayerController playerController;
    private InputAction pickup;

    bool canPickup = true;
    private GameObject pickupHand;

    private GameObject pickedUpItem;
    private bool inRangeOfItem = false;

    // Start is called before the first frame update
    void Start()
    {
        pickupHand = GameObject.Find("pickupHand");

    }

    //---------- Pickup action --------------------

    bool CheckForItem()
    {

        RaycastHit hit;
        if (canPickup && (Physics.Raycast(frontRay, out hit, maxDistance, layerMask) || Physics.Raycast(leftRay, out hit, maxDistance, layerMask) || Physics.Raycast(rightRay, out hit, maxDistance, layerMask) || Physics.Raycast(backRay, out hit, maxDistance, layerMask)))
        {
            
            pickedUpItem = hit.collider.gameObject;
            canPickup = false;
            if (pickedUpItem.CompareTag("Cleaning"))
            {
                EventManager.current.PickedUpCleaningItem();
            }
            else if (pickedUpItem.CompareTag("Roomservic"))
            {
                EventManager.current.PickedUpRoomservicItem();
            }
            return true;
        }
        return false;
    }

    //---------- Change position -------------------

    void ChangePosition(GameObject objectHit)
    {
            objectHit.transform.position = pickupHand.transform.position;
            objectHit.GetComponent<Collider>().enabled = false;
            objectHit.GetComponent<Rigidbody>().useGravity = false;
            //holding = true;
    }

    void DropItem()
    {
            Debug.Log("drop");
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
        //Debug.Log(transform.forward);
        frontRay = new Ray(transform.position, transform.forward);
        backRay = new Ray(transform.position, -transform.forward);
        leftRay = new Ray(transform.position, -transform.right);
        rightRay = new Ray(transform.position, transform.right);

        if (canPickup && inRangeOfItem)
        {
            pickup.performed += checkKeypress;
            
        }

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

    }

    void checkKeypress(InputAction.CallbackContext context){
        if(!holding){
            //CheckForItem();
            PickUpItem();
            
        }
        else{
            DropItem();
        }
    }

    private void OnDisable()
    {
        pickup.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        pickup.Enable();
        if(other.gameObject.layer == LayerMask.NameToLayer("Pickupable"))
        {
            pickedUpItem = other.gameObject;
            inRangeOfItem = true;
        }
        

    }

    private void PickUpItem()
    {
        //pickup.Enable();
            //canPickup = false;
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
        pickup.Disable();
        pickedUpItem = null;
        inRangeOfItem = false;
        
    }
}
