using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;


public class ResultManager : MonoBehaviour
{
    [SerializeField] UnityEvent RetryClickEvent = new UnityEvent();
    [SerializeField] UnityEvent TitleClickEvent = new UnityEvent();

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Time.timeScale = 1;
            //�^�C�g���V�[���ւ̐؂�ւ�
            Cursor.visible = true;
            SceneManager.LoadScene("TitleScene");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            //�v���C��ʂֈړ�
            SceneManager.LoadScene("GamePlayScene");
        }

    }

    public void RetryClick()
    {
        //Debug.Log("�V�[���ړ��Q�[��");
        Time.timeScale = 1;
        SceneManager.LoadScene("GamePlayScene");
   
    }

    public void TitleClick()
    {
       // Debug.Log("�V�[���ړ��^�C�g��");
        Time.timeScale = 1;
        Cursor.visible = true;
        SceneManager.LoadScene("TitleScene");
    }
}
