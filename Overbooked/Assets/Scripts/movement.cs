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

    private float horisontal;

    private Animator ani;

    private Vector2 moveDirection;

    public PlayerController playerController;
    private InputAction move;


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
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
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

 

}
