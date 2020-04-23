using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{

    public Animator animator;

    public GameObject sprite;

    private bool facingRight = true; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        animator.SetFloat("SpeedX", Mathf.Abs(horizontal.x));
        animator.SetFloat("SpeedY", Mathf.Abs(horizontal.y));
        animator.SetFloat("Magnitude", Mathf.Abs(horizontal.magnitude));

        transform.position = transform.position + horizontal * Time.deltaTime;
        flip();
    }

    private void flip(){
        if (Input.GetAxis("Horizontal") > 0 && !facingRight || Input.GetAxis("Horizontal") < 0 && facingRight){
            facingRight = !facingRight;
            Vector3 scale = sprite.transform.localScale;
            scale.x *= -1;
            sprite.transform.localScale = scale;
        }
    }

}
