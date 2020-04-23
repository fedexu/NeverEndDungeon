using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator animator;
    public GameObject sprite;
    public Rigidbody2D body;

    private Vector3 movement;

    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        processInput();
        move();
        animate();
    }

    private void processInput()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
    }

    private void move()
    {
        //transform.position = transform.position + movement * Time.deltaTime;
        body.velocity = new Vector2(movement.x, movement.y);
    }


    private void animate()
    {
        animator.SetFloat("SpeedX", Mathf.Abs(movement.x));
        animator.SetFloat("SpeedY", Mathf.Abs(movement.y));
        animator.SetFloat("Magnitude", Mathf.Abs(movement.magnitude));

        flip();
    }

    private void flip()
    {
        if (Input.GetAxis("Horizontal") > 0 && !facingRight || Input.GetAxis("Horizontal") < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 scale = sprite.transform.localScale;
            scale.x *= -1;
            sprite.transform.localScale = scale;
        }
    }

}
