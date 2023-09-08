using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScoreManager : MonoBehaviour
{
    
    public Text scoreText;
    private int score;
    private int highScore;

    private void Start()
    {
        score = ScoreAndHighScore.GetScore();
        scoreText.text = string.Format("Score:{0}", score);
        highScore = ScoreAndHighScore.GetHighScore();
        Save(highScore);
    }
    public void Save(int highScore)
    {
        // ハイスコアを保存する
        PlayerPrefs.SetInt("highScore", highScore);
        PlayerPrefs.Save();
        //Debug.Log("とんでもねぇ待ってたんだ");
    }


}
