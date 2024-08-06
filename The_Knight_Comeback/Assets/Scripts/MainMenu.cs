using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Tải Scene bằng Build Index
        SceneManager.LoadScene(1); // Thay 1 bằng Build Index của Scene bạn muốn load

        // Hoặc tải Scene bằng tên
        // SceneManager.LoadScene("GameScene"); // Thay "GameScene" bằng tên Scene bạn muốn load
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
