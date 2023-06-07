using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UncleManeger : MonoBehaviour
{
    [SerializeField] Animator animater;
    [SerializeField] Image image;
    [SerializeField] float uncleComeMinTimer = 5f;
    [SerializeField] float uncleComeMaxTimer = 8f;
    [SerializeField] float uncleWaitMinTimer = 3f;
    [SerializeField] float uncleWaitMaxTimer = 5f;
    [SerializeField] float warningTimer = 1f;


    float comeTimer;
    float waitTimer;
    float timer;
    bool  animSet;

    // Start is called before the first frame update
    void Awake()
    {
        animSet = false;
        comeTimer = Random.Range(uncleComeMinTimer, uncleComeMaxTimer);
        waitTimer = comeTimer + Random.Range(uncleWaitMinTimer, uncleWaitMaxTimer);
    }

    // Update is called once per frame
    void Update()
    {
        if (ReceiveEvent.btns[0] == false)
        {
            timer += Time.deltaTime;
        }


        if (timer >= comeTimer && animSet == false)
        {
            Debug.Log(comeTimer);
            Debug.Log(comeTimer - warningTimer);
            animater.SetTrigger("Come");
            animSet = true;
            image.color = new Color(1, 0, 0, 0);
        }
        else if (timer >= comeTimer-warningTimer && animSet == false)
        {
           
            image.color = new Color(1,0,0,1);
        }
        if (timer >= waitTimer && animSet == true)
        {
            animater.SetTrigger("Back");
            comeTimer = Random.Range(uncleComeMinTimer, uncleComeMaxTimer);
            waitTimer = comeTimer + Random.Range(uncleWaitMinTimer, uncleWaitMaxTimer);
            timer = 0;
            animSet = false;
            
        }
       
        
    }
}
