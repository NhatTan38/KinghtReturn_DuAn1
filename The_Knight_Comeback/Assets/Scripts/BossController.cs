using UnityEngine;

public class BossController : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    public float attackRange = 2f;
    public float attackRate = 1f;
    private float nextAttackTime = 0f;
    public float moveSpeed = 2f;
    private bool isPlayerInRange = false;
    private bool isFacingRight = true; // Thêm biến này để kiểm soát hướng của Boss

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        // Tìm player trong scene
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null)
            return;

        // Kiểm tra khoảng cách giữa Boss và Player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            isPlayerInRange = true;
            if (Time.time >= nextAttackTime)
            {
                nextAttackTime = Time.time + 1f / attackRate;
                Attack();
            }
        }
        else
        {
            isPlayerInRange = false;
        }

        if (isPlayerInRange)
        {
            // Nếu Player trong phạm vi, di chuyển về phía Player
            MoveTowardsPlayer();
        }
        else
        {
            // Nếu Player ngoài phạm vi, chuyển sang trạng thái Idle
            animator.SetBool("IsWalking", false);
        }

        // Kiểm tra và xoay mặt Boss theo hướng Player
        FlipTowardsPlayer();
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }

    void MoveTowardsPlayer()
    {
        animator.SetBool("IsWalking", true);
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    void FlipTowardsPlayer()
    {
        // Kiểm tra vị trí của Player để xoay mặt Boss
        if (player.position.x > transform.position.x && !isFacingRight)
        {
            Flip();
        }
        else if (player.position.x < transform.position.x && isFacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1; // Xoay mặt Boss bằng cách đổi dấu trục x của localScale
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Gọi hàm Hurt hoặc phương thức khác khi va chạm với player
            // collision.GetComponent<PlayerController>().TakeDamage(damageAmount);
        }
    }

    public void Fly()
    {
        animator.SetTrigger("Flying");
    }

    public void Hurt()
    {
        animator.SetTrigger("Hurt");
    }

    public void Die()
    {
        animator.SetTrigger("Die");
    }
}
