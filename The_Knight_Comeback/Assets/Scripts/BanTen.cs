using UnityEngine;

public class BanTen : MonoBehaviour
{
    public Transform firePoint; // Vị trí xuất phát của mũi tên
    public GameObject arrowPrefab; // Prefab của mũi tên Arrow
    public float arrowSpeed = 20f; // Tốc độ của mũi tên
    public float fireRate = 0.5f; // Tốc độ bắn
    public float arrowLifetime = 2f; // Thời gian tồn tại của viên đạn
    private float nextFireTime = 0f; // Thời gian tiếp theo có thể bắn

    void Update()
    {
        // Kiểm tra nếu phím J được nhấn và thời gian đã đến để bắn viên tiếp theo
        if (Input.GetKeyDown(KeyCode.J) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate; // Cập nhật thời gian tiếp theo có thể bắn
            Shoot();
        }
    }

    void Shoot()
    {
        // Tạo mũi tên tại vị trí và hướng của firePoint
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.right * arrowSpeed; // Đặt tốc độ cho mũi tên
        }

        // Hủy viên đạn sau một khoảng thời gian
        Destroy(arrow, arrowLifetime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu viên đạn va chạm vào tilemap hoặc enemy
        if (collision.CompareTag("Tilemap") || collision.CompareTag("Enemy"))
        {
            // Hủy GameObject của viên đạn khi va chạm
            Destroy(gameObject);
        }
    }
}
