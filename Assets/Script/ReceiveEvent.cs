using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ReceiveEvent : MonoBehaviour
{
    public static bool[] btns;
    public static bool check = false;
    public static float timer;



    bool setBtn = false;
    bool manualBtn = false;
    bool levelBtn = false;
    int setNum = 0;
    int manualNum = 1;
    int levelNum = 2;
    int select;

    [SerializeField] GameObject manualPanel;
    [SerializeField] UnityEvent CloseSetting = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        manualPanel.SetActive(false);
        btns = new bool[] { setBtn, manualBtn, levelBtn };
    }



    public void SetEvent()
    {
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

    void MyPointerDownUI(int pushBtn, bool[] btns)
    {
        CheckBtn(btns);

        if (check == false)
        {
            btns[pushBtn] = true;
            manualPanel.SetActive(btns[pushBtn]);
            timer = 0f;
        }
        else if (btns[pushBtn] == true && check == true)
        {
            if (setBtn == false)
            {
                CloseSetting.Invoke();
            }

            btns[pushBtn] = false;
            manualPanel.SetActive(btns[pushBtn]);
            timer = 0f;
            

            
        }

    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }

    public static void CheckBtn(bool[] btns)
    {
        check = false;
        foreach (bool btn in btns)
        {
            if (btn == true)
            {
                check = true;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}