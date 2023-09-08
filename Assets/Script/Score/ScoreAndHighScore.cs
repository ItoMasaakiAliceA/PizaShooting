using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndHighScore : MonoBehaviour
{
    // �X�R�A��\������UI�̎擾�p
    [SerializeField]
    Text scoreTx;
    [SerializeField]
    Text highScoreTx;

    public static Text scoreText;


    // �X�R�A�̃J�E���g�p
    public static int score;

    // �n�C�X�R�A�̃J�E���g�p
    private static int highScore;
    //private static bool New = false;



    public static int GetScore()
    {
        //�X�R�A����܁[��
        return score;
    }

    /*public static bool GetNew()
    {
        return New;
    }*/

    public static int GetHighScore()
    {
        //�n�C�X�R�A����܁[��
        return highScore;
    }

    void Start()
    {
        scoreText = scoreTx;
        Initialize();
    }

    // �Q�[���J�n�O�̏�Ԃɖ߂�
    private void Initialize()
    {
        // �X�R�A��0�ɖ߂�
        score = 0;
        // highScoreKey�̒l�ŕۑ�����Ă���n�C�X�R�A���������Ď擾����B�ۑ�����ĂȂ����0���擾����B
        highScore = PlayerPrefs.GetInt("highScore", 0);
        //Debug.Log(highScore);
        highScoreTx.text = "HighScore:" + highScore.ToString();
    }

    // �|�C���g�̒ǉ��B�C���q��public�ɂ��Ă���̂ŊO�����Q�Ƃł��郁�\�b�h�ɂȂ��Ă���
    public static void AddPoint(int point)�@�@�@�@�@�@//�@�O�����󂯎����int�^�̈�����point�Ƃ��Ď󂯎��
    {
        score += point;
       // Debug.Log(score);                       // �����Ŋm�F����ƁA�u���b�N����̏�񂪓͂��Ă��邩�m�F�ł���B�\������Ȃ���Γ͂��Ă��Ȃ��Ƃ������ƂɂȂ�B

        // �X�R�A���n�C�X�R�A���傫���Ȃ�΁A�n�C�X�R�A���X�V����
        if (highScore < score)
        {
            highScore = score;
           // New = true;

           // Debug.Log(highScore);               // �n�C�X�R�A�̍X�V������ɍs��ꂽ���m�F�ł���
        }

        // �Q�[����ʏ�̃X�R�A�ƃn�C�X�R�A�̕\�����X�V����
        DisplayScores();
        
    }

    // �Q�[����ʏ�̃X�R�A�ƃn�C�X�R�A�̕\�����X�V����
    public  static void DisplayScores()
    {
        // ���݂̃X�R�A�ƃn�C�X�R�A����ʂɕ\������
        //Debug.Log(score.ToString());
        scoreText.text = "Score:" + score.ToString();

    }

    // �n�C�X�R�A�̕ۑ�
    /*public void Save(int highScore)
    {
        // �n�C�X�R�A��ۑ�����
        PlayerPrefs.SetInt("highScore", highScore);
        PlayerPrefs.Save();

        // �Q�[���J�n�O�̏�Ԃɖ߂�
        Initialize();
        Debug.Log("�Ƃ�ł��˂��҂��Ă���");
    }*/


}
