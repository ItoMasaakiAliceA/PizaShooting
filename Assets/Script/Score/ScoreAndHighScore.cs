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
    // �n�C�X�R�A��\������UI�̎擾�p
    public static Text highScoreText;

    // �X�R�A�̃J�E���g�p
    private static int score;

    // �n�C�X�R�A�̃J�E���g�p
    private static int highScore;

    // PlayerPrefs�ŕۑ����邽�߂̃L�[
    private string highScoreKey = "highScore";

    void Start()
    {
        scoreText = scoreTx;
        highScoreText = highScoreTx;
        Initialize();
    }

    // �Q�[���J�n�O�̏�Ԃɖ߂�
    private void Initialize()
    {
        // �X�R�A��0�ɖ߂�
        score = 0;

        // highScoreKey�̒l�ŕۑ�����Ă���n�C�X�R�A���������Ď擾����B�ۑ�����ĂȂ����0���擾����B
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
    }

    // �|�C���g�̒ǉ��B�C���q��public�ɂ��Ă���̂ŊO�����Q�Ƃł��郁�\�b�h�ɂȂ��Ă���
    public static void AddPoint(int point)�@�@�@�@�@�@//�@�O�����󂯎����int�^�̈�����point�Ƃ��Ď󂯎��
    {
        score += point;
        Debug.Log(score);                       // �����Ŋm�F����ƁA�u���b�N����̏�񂪓͂��Ă��邩�m�F�ł���B�\������Ȃ���Γ͂��Ă��Ȃ��Ƃ������ƂɂȂ�B

        // �X�R�A���n�C�X�R�A���傫���Ȃ�΁A�n�C�X�R�A���X�V����
        if (highScore < score)
        {
            highScore = score;

            Debug.Log(highScore);               // �n�C�X�R�A�̍X�V������ɍs��ꂽ���m�F�ł���
        }

        // �Q�[����ʏ�̃X�R�A�ƃn�C�X�R�A�̕\�����X�V����
        DisplayScores();
    }

    // �Q�[����ʏ�̃X�R�A�ƃn�C�X�R�A�̕\�����X�V����
    private static void DisplayScores()
    {
        // ���݂̃X�R�A�ƃn�C�X�R�A����ʂɕ\������
        Debug.Log(score.ToString());
        scoreText.text = "Score:" + score.ToString();
        highScoreText.text = "HighScore:" + highScore.ToString();
    }

    // �n�C�X�R�A�̕ۑ�
    public void Save()
    {
        // �n�C�X�R�A��ۑ�����
        PlayerPrefs.SetInt(highScoreKey, highScore);
        PlayerPrefs.Save();

        // �Q�[���J�n�O�̏�Ԃɖ߂�
        Initialize();
    }
}
