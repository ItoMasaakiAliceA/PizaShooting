using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ResultManager : MonoBehaviour
{
    [SerializeField] UnityEvent RetryClickEvent = new UnityEvent();
    [SerializeField] UnityEvent TitleClickEvent = new UnityEvent();

    public void Update()
    {
        
    }

    public void RetryClick()
    {
        Debug.Log("シーン移動ゲーム");
        SceneManager.LoadScene("GamePlayScene");
    }

    public void TitleClick()
    {
        Debug.Log("シーン移動タイトル");
        SceneManager.LoadScene("TitleScene");
    }
}
