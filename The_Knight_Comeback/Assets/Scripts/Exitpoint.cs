using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exitpoint : MonoBehaviour
{
    private float _levelLoandDelay = 2f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) ;
        {
            StartCoroutine(LoadNextLevel());
        }
    }
    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(_levelLoandDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
