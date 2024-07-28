using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;

    [SerializeField]
    private float leftBoundary;

    [SerializeField]
    private float righttBoundary;

    public Animator _animator;


    public int _maxHealth = 100;
    int _currentHealth;


    // quai di chuyen phai
    private bool _isMovingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
    }
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        // hiệu ứng đau
        _animator.SetTrigger("isHit");
        

        if (_currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("ememy die1!");

        // hiệu ứng chết
        _animator.SetBool("isDead", true);

        // vô hiệu hóa quái
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        // lay vi tri hien tai cua quai
        var currentPosition = transform.localPosition;
        if (currentPosition.x > righttBoundary)
        {
            // neu vi tri hien tai cua quai > rightBoundary
            // di chuyen trai
            _isMovingRight = false;
        }
        else if (currentPosition.x < leftBoundary)
        {
            // neu vi tri hien tai cua quai < leftBoundary
            // di chuyen phai
            _isMovingRight = true;
        }

        // di chuyen ngang
        var direction = Vector3.right;
        if (_isMovingRight == false)
        {
            direction = Vector3.left;
        }

        //var direction = _isMovingRight ? Vector3.right : Vector3.left;
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        // scale hien tai 
        // mat: trai > 0, phai < 0
        var currentScale = transform.localScale;
        if ((_isMovingRight == true && currentScale.x < 0) || (_isMovingRight == false && currentScale.x > 0))
        {
            currentScale.x *= -1;
        }
        transform.localScale = currentScale;
    }
}
