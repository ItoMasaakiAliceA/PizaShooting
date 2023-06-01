using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReceiveEvent : MonoBehaviour
{
    public static bool[] btns;

   

    bool setBtn = false;
    bool manualBtn = false;
    bool levelBtn = false;
    int setNum = 0;
    int manualNum = 1;
    int levelNum = 2;
    int select;
    
    [SerializeField] GameObject manualPanel;
    // 音量設定用
    [SerializeField] UnityEvent EndPauseEvent = new UnityEvent();


    // Start is called before the first frame update
    void Start()
    {
        manualPanel.SetActive(false);
        btns = new bool[] { setBtn, manualBtn, levelBtn};
    }



    public void SetEvent() {
        MyPointerDownUI(setNum, btns);
    }

    public void ManualEvent()
    {
        MyPointerDownUI(manualNum, btns);
    }

    public void LevelEvent()
    {
        MyPointerDownUI(levelNum, btns);
    }

    void MyPointerDownUI(int pushBtn,bool[] btns )
    {
        bool check = false;

        foreach(bool btn in btns)
        {
            if(btn == true)
            {
                check = true;
                

            }
        }

        if(check == false )
        {
            btns[pushBtn] = true;
            manualPanel.SetActive(btns[pushBtn]);
            TitleManeger.timer = 0f;
        }
        else if(btns[pushBtn] == true && check == true)
        {
            btns[pushBtn] = false;
            manualPanel.SetActive(btns[pushBtn]);
            TitleManeger.timer = 0f;

            //　ここでセーブ
            EndPauseEvent.Invoke();
        }
        
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
