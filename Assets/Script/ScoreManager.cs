using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        // 初期スコア
        SetScore();
    }

    public void HitBullet(string hittag)
    {
        // ここは実際の的のタグに変える
        if (hittag == "target")
        {
            score += 100;
        }

        SetScore();
       
    }

    void SetScore()
    {
        scoreText.text = string.Format("Score:{0}", score);

    }
}

