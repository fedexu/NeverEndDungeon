using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator animator;
    public GameObject sprite;
    public Rigidbody2D body;

    private Vector3 movement;
    private RoomTemplates templates;
    [SerializeField] private bl_Joystick Joystick;

    private bool facingRight = true;

    void Awake()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Joystick = FindObjectOfType<bl_Joystick>();
    }

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
        if (templates.isCompletedCreation())
        {
                movement = new Vector3(Limit(Joystick.Horizontal) + Limit(Input.GetAxis("Horizontal")),
                 Limit(Joystick.Vertical) + Limit(Input.GetAxis("Vertical")), 0.0f);
        }
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
        if (movement.x > 0 && !facingRight || movement.x < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 scale = sprite.transform.localScale;
            scale.x *= -1;
            sprite.transform.localScale = scale;
        }
    }

    private float Limit(float number)
    {
        if (number > 0f)
        {
            if (number > 1f)
            {
                return 1f;
            }
            else
            {
                return number;
            }
        }
        else
        {
            if (number < -1f)
            {
                return -1f;
            }
            else
            {
                return number;
            }
        }
    }

}
