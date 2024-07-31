using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private bool isJumping = false;
    private bool isAttacking = false;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
            animator.SetBool("isJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            isAttacking = true;
            animator.SetTrigger("Attack");  // Sử dụng SetTrigger thay vì SetBool
        }

        // Kiểm tra nếu nhân vật đang trên mặt đất
        if (Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            isGrounded = true;
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
        else
        {
            isGrounded = false;
        }
    }
}
