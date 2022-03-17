using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    public bool isGrounded;

    float dirX;

    public SpriteRenderer renderer;
    public Animator _animator;
    Rigidbody2D _rBody;

     void Awake()
    {
       _animator = GetComponent<Animator>();
       _rBody = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {
       dirX = Input.GetAxisRaw("Horizontal");

       Debug.Log(dirX);

       //transform.position += new Vector3(dirX, 0, 0) * speed * Time.deltaTime;


       if(dirX == -1)
       {
           renderer.flipX = true;
           _animator.SetBool("Running", true);
       }
       else if (dirX == 1)
       {
           renderer.flipX = false;
           _animator.SetBool("Running", true);
       }
       else
       {
           _animator.SetBool("Running", false);
       }

       if(Input.GetButtonDown("Jump") && isGrounded)
       {
           _rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
           _animator.SetBool("Jumping", true);
       }
    }

    void FixedUpdate()
    {
        _rBody.velocity = new Vector2(dirX * speed, _rBody.velocity.y);
    }

   
}
