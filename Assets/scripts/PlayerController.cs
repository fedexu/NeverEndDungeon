using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private GameController gameController;
    public Animator animator;
    public GameObject sprite;
    public Rigidbody2D body;

    private Vector3 movement;
    private RoomTemplates templates;
    [SerializeField] private FloatingJoystick Joystick;

    private bool facingRight = true;

    void Awake()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Joystick = FindObjectOfType<FloatingJoystick>();
        gameController = FindObjectOfType<GameController>();
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
        if (templates.isCompletedCreation() && gameController.isPlaying)
        {
            movement = new Vector3(movement8Axis(Joystick.Horizontal) + movement8Axis(Input.GetAxis("Horizontal")),
             movement8Axis(Joystick.Vertical) + movement8Axis(Input.GetAxis("Vertical")), 0.0f);
        }
    }

    private void move()
    {
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

    private float movement8Axis(float number)
    {
        if (number > 0.010f)
        {
            if (number > 0.75f)
            {
                return 1f;
            }
            if (number > 0.25f && number < 0.75f)
            {
                return 0.5f;
            }
        }
        if (number < -0.010f)
        {
            if (number < -0.75f)
            {
                return -1f;
            }
            if (number < -0.25f && number > -0.75f)
            {
                return -0.5f;
            }
        }
        return 0f;

    }

}
