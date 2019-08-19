using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{

    private int score = 0;
    public Text scoreText;

    public void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    public void AddScore(int val)
    {
        score += val;
        UpdateScore();
    }
}
