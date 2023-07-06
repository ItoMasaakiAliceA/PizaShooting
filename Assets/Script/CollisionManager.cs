using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionManager : MonoBehaviour
{
    public Text scoreText; //Text�p�ϐ�
    private int score = 0; //�X�R�A�v�Z�p�ϐ�

    void Start()
    {
        score = 0;
        SetScore();   //�����X�R�A�������ĕ\��
    }

    void OnCollisionEnter(Collision collision)
    {
        string yourTag = collision.gameObject.tag;

        if (yourTag == "piza")
        {
            score += 100;
            SetScore();
        }
        
    }

    void SetScore()
    {
        scoreText.text = string.Format("Score:{0}", score);
    }
}
