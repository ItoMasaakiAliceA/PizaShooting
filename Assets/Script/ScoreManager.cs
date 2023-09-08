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
        // �����X�R�A
        SetScore();
    }

    public void HitBullet(string hittag)
    {
        // �����͎��ۂ̓I�̃^�O�ɕς���
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

