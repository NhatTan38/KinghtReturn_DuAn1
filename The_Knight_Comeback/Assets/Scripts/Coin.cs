using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Tăng điểm số hoặc làm bất kỳ hành động nào khác bạn muốn khi player thu thập coin
            Destroy(gameObject);
        }
    }
}
