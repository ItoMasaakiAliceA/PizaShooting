using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OptionScript : MonoBehaviour
{
    [SerializeField] GameObject OptionManager;
    [SerializeField] UnityEvent EndPauseEvent = new UnityEvent();
    [SerializeField] UnityEvent EscEvent = new UnityEvent();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscEvent.Invoke();

            OptionManager.SetActive(!OptionManager.activeSelf);

            //Debug.Log(OptionManager.activeSelf);

            if (OptionManager.activeSelf == true)
            {
                Time.timeScale = 0;
            }

            if (OptionManager.activeSelf == false)
            {
                Time.timeScale = 1;

                //　ここでセーブ
                EndPauseEvent.Invoke();
            }


        }
    }
}
