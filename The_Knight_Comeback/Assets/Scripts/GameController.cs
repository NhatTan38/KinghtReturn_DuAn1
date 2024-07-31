using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] int live = 3;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI liveText;

    // Start is called before the first frame update
    void Start()
    {
        liveText.text = live.ToString();
        scoreText.text = score.ToString();
    }
    // tăng điểm
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd; 
        scoreText.text = score.ToString();
    }  


    // Update is called once per frame
    void Update()
    {
        
    }
}
