using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;
    public float speed = 2.5f;

    private float input_x = 0;
    private float input_y = 0;
    private bool isWalking = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        input_x = Input.GetAxisRaw("Horizontal");
        input_y = Input.GetAxisRaw("Vertical");
        isWalking = (input_x != 0 || input_y != 0);

        playerAnimator.SetFloat("Input_X", input_x);
        playerAnimator.SetFloat("Input_Y", input_y);
        playerAnimator.SetBool("isWalking", isWalking);

        // DEBUG
        Debug.Log($"isWalking: {isWalking} | Input: ({input_x}, {input_y})");

        if (Input.GetButtonDown("Fire1"))
            playerAnimator.SetTrigger("attack");
    }

    void FixedUpdate()
    {
        Vector2 move = new Vector2(input_x, input_y).normalized;
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }
}