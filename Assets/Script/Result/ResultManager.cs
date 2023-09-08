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
            //タイトルシーンへの切り替え
            Cursor.visible = true;
            SceneManager.LoadScene("TitleScene");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            //プレイ画面へ移動
            SceneManager.LoadScene("GamePlayScene");
        }

    }

    public void RetryClick()
    {
        //Debug.Log("シーン移動ゲーム");
        Time.timeScale = 1;
        SceneManager.LoadScene("GamePlayScene");
   
    }

    public void TitleClick()
    {
       // Debug.Log("シーン移動タイトル");
        Time.timeScale = 1;
        Cursor.visible = true;
        SceneManager.LoadScene("TitleScene");
    }
}
