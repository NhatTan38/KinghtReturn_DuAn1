using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanDan : MonoBehaviour
{

    // tạo tham chiếu đến viên đạn và súng
    [SerializeField] 
    private GameObject _bulletPrefab;
    [SerializeField]
    private Transform _gun;

    [SerializeField]
    private bool _isMovingRight = true;
    [SerializeField] float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        File();
    }

    // Hàm xử lý bắn đạn 
    private void File()
    {
        // nếu người chơi nhấn phím k
        if (Input.GetKeyDown(KeyCode.K))
        {
            // tạo ra viên đạn tại vị trí của súng
            var bullet = Instantiate(_bulletPrefab, _gun.position, Quaternion.identity);
            // cho viên đạn bay theo hướng mặt
            var velocity = new Vector3(50f, 0);
            if (_isMovingRight == false)
            {
                velocity.x *= -1;
            }
            bullet.GetComponent<Rigidbody2D>().velocity = velocity;
            // hủy viên đạn sau 2 giây
            Destroy(bullet, 2f);
        }
    }
    void OnMove(/*InputValue value*/)
    {
        //if (!isAlive)
        //{
        //    return;
        //}
        //moveInput = value.Get<Vector2>();
        //Debug.Log(">>>Move Input: " + moveInput);

        // left, right, a, d 
        var horizontalInput = Input.GetAxis("Horizontal");
        // 0: không nhấn, âm: trái, dương: phải
        // điều khiển trái phải 
        transform.localPosition += new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime;

        // localPosition: vị trí trương đối so với cha
        // position: vị trí tuyệt đối so với thế giới 
        if (horizontalInput > 0)
        {
            _isMovingRight = true;
        }
        else if (horizontalInput < 0)
        {
            _isMovingRight = false;
        }

        // xoay nhân vật  
        transform.localScale = _isMovingRight ? new Vector2(1, 1) : new Vector2(-1, 1);
    }
}
