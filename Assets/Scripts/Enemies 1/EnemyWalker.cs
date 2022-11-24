using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyWalker : Enemy
{
    Rigidbody2D rb;
    public float speed;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask isGroundLayer;
    public bool isGrounded;

    // Start is called before the first frame update
    public override void Start()
    {  
        base.Start();
        rb = GetComponent<Rigidbody2D>();

        if (speed <= 0)
            speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorClipInfo[] curClips = anim.GetCurrentAnimatorClipInfo(0);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

        if (curClips[0].clip.name == "Walk")
        {
            if (sr.flipX)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }

        anim.SetBool("isGrounded", isGrounded);

        if (!groundCheck) // need this to trigger Walk animation when enemy lands from floating in
        {
            groundCheck = GameObject.FindGameObjectWithTag("GroundCheck").transform;
            Debug.Log("Ground Check Not Set - Finding it Manually");
        }

        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.2f;
            Debug.Log("Ground Check Radius Not Set - Default set to 0.2");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Barrier"))
        {
            sr.flipX = !sr.flipX;
        }
        
        if (collision.CompareTag("Enemy"))
        {
            sr.flipX = !sr.flipX;
        }

        if (collision.CompareTag("PlayerProjectile"))
            Destroy(gameObject);
    }

    public void DestroyMyself()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
