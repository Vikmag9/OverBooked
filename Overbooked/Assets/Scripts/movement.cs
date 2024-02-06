using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class movement : MonoBehaviour
{

    private Vector3 velocity;
    public Rigidbody rb3D;

    private float speed = 5f;
    private Boolean inAir;

    private Animator ani;

    private Vector2 moveDirection;
    public PlayerController playerController;
    private InputAction move;
    private InputAction jump;
    private InputAction dance;


    // Start is called before the first frame update
    void Start()
    {
        rb3D = this.GetComponent<Rigidbody>();
        velocity = new Vector3(1f, 1f, 0f);
        ani = this.GetComponent<Animator>();
    }
    private void Awake()
    {
        playerController = new PlayerController();
    }
    private void OnEnable()
    {
        move = playerController.Player.Move;
        jump = playerController.Player.Jump;
        dance = playerController.Player.Dance;

        move.Enable();
        jump.Enable();
        dance.Enable();

        jump.performed += Jump;
        dance.performed += Dance;
    }

    private void OnDisable()
    {
        move.Disable();
        jump.Disable();
        dance.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        //horisontal = Input.GetAxisRaw("Horizontal");
        //float vertical = Input.GetAxisRaw("Vertical");
        ani.SetFloat("horisontal_var", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        moveDirection = move.ReadValue<Vector2>();

    }

    void FixedUpdate(){
        Move();
    }

    void Move()
    {
        rb3D.velocity = new Vector3(moveDirection.x * speed, rb3D.velocity.y, rb3D.velocity.z);
        this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, 180 - moveDirection.x * 90, this.transform.rotation.z);
    }

    void Jump(InputAction.CallbackContext contex)
    {
        if (!inAir) 
        {
            inAir = true;
            rb3D.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }
    }

    void Dance(InputAction.CallbackContext contex)
    {
        ani.SetFloat("dance_var", 1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            inAir = false;
        }
    }

}
