using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerrun : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float jumpforce;
    public float moveInput;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool movent = false;

    private bool isGrouunded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask Ground;

    private int extraJump;
    public int extraJumpsValue;

    // Start is called before the first frame update
    void Start()
    {
        extraJump = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()

    {
       
        isGrouunded = Physics2D.OverlapCircle(groundCheck.position, checkRadius,Ground);
        moveInput = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(moveInput));
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
     

    }
    void FixedUpdate()
     {
        animator.SetBool("jumping", isGrouunded);
        if (isGrouunded == true)
        {
            animator.SetBool("jumping", isGrouunded);
            extraJump = extraJumpsValue;
        }
        if (Input.GetKeyDown(KeyCode.Space)&&extraJump>0)
        {
            rb.velocity = Vector2.up * jumpforce;
            extraJump--;
        }else if (Input.GetKeyDown(KeyCode.Space) && extraJump == 0&&isGrouunded==true)
        {
            rb.velocity = Vector2.up * jumpforce;
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
