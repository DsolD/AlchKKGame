using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController: MonoBehaviour
{

    public float speed;
 //   public Animator Animator;
    private Rigidbody2D rb;
    private Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

//        Animator.SetFloat("Horizontal", direction.x);
 //       Animator.SetFloat("Vertical", direction.y);
  //      Animator.SetFloat("Speed", direction.sqrMagnitude);

    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

    }



}
