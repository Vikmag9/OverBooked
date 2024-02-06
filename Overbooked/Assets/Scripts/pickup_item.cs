using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class pickup_item : MonoBehaviour
{

    Ray frontRay;
    Ray leftRay;
    Ray rightRay;

    bool frontRayCast;
    bool leftRayCast;
    bool rightRayCast;
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
        if (canPickup && (Physics.Raycast(frontRay, out hit, maxDistance, layerMask) || Physics.Raycast(leftRay, out hit, maxDistance, layerMask) || Physics.Raycast(rightRay, out hit, maxDistance, layerMask)))
        {
            
            pickedUpItem = hit.collider.gameObject;
            canPickup = false;
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
    }

    void DropItem()
    {
            Debug.Log("drop");
            pickedUpItem.GetComponent<Collider>().enabled = true;
            pickedUpItem.GetComponent<Rigidbody>().useGravity = true;
            pickedUpItem = null;
            canPickup = true;
    }

    //---------- Update ---------------------------

    void FixedUpdate() {
        if(pickedUpItem != null){
            ChangePosition(pickedUpItem);
        }
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.forward);
        frontRay = new Ray(transform.position, transform.forward);
        leftRay = new Ray(transform.position, -transform.right);
        rightRay = new Ray(transform.position, transform.right);
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


        pickup.performed += checkKeypress;

    }

    void checkKeypress(InputAction.CallbackContext context){
        if(canPickup){
            CheckForItem();
        }else{
            DropItem();
        }
    }

    private void OnDisable()
    {
        pickup.Disable();
    }
}
