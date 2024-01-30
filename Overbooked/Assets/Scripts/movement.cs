using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    private Vector3 velocity;
    public Rigidbody rb3D;

    private float speed = 5f;

    private float horisontal;

    private Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        rb3D = this.GetComponent<Rigidbody>();

        velocity = new Vector3(1f, 1f, 0f);

        ani = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horisontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        ani.SetFloat("horisontal_var", Mathf.Abs(Input.GetAxisRaw("Horizontal")));

    }

    void FixedUpdate(){
        rb3D.velocity = new Vector3(horisontal * speed, rb3D.velocity.y, rb3D.velocity.z);

    }

}
