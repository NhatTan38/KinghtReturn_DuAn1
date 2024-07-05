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

    // quai di chuyen phai
    private bool _isMovingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
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
