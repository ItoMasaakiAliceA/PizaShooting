using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class TitleManeger : MonoBehaviour
{
    [SerializeField] float timeBetweenClicks = 0.15f;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] UnityEvent PushClick = new UnityEvent();

    public static TextMeshProUGUI levelText;


    // Start is called before the first frame update
    void Start()
    {
        levelText = text;
        LevManeger.Level = LevManeger.easy;
        TitleManeger.levelText.text = "EASY";
        levelText.color = new Color(0f, 1f, 0.196f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        ReceiveEvent.CheckBtn(ReceiveEvent.btns);
        
        //Debug.Log("TitleCheck = " + check);

        if (Input.GetMouseButtonDown(0) && ReceiveEvent.check == false && ReceiveEvent.timer >= timeBetweenClicks &&
            Time.timeScale != 0)
        {
            Debug.Log("Start");
            SceneManager.LoadScene(1);
        }
        if (Input.GetMouseButtonDown(0))
        {
            PushClick.Invoke();
        }

        ReceiveEvent.timer += Time.deltaTime;
    }

}
