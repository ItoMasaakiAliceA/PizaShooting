using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PizaManeger : MonoBehaviour
{
    [SerializeField] float easyWaitTime = 1.5f;
    [SerializeField] float normalWaitTime = 0.4f;
    [SerializeField] float hardWaitTime = 0.2f;
    [SerializeField] int minPizaRad = 30;
    [SerializeField] int maxPizaRad = 60;

    [SerializeField] GameObject PizaR;
    [SerializeField] GameObject PizaL;
    [SerializeField] Image timerImage;


    [SerializeField] float easyMinSpeed = 0.02f;
    [SerializeField] float easyMaxSpeed = 0.04f;
    [SerializeField] float normalMinSpeed = 0.05f;
    [SerializeField] float normalMaxSpeed = 0.1f;
    [SerializeField] float hardMinSpeed = 0.1f;
    [SerializeField] float hardMaxSpeed = 0.2f;
    [SerializeField] float insMinSpeed = 0.5f;
    [SerializeField] float insMaxSpeed = 2.0f;
    [SerializeField] float maxTimer = 30f;


    public static float wait;
    public static float minSpeed;
    public static float maxSpeed;
    public static int score;

    public static float minRad;
    public static float maxRad;

    public const int easy = 1;
    const int normal = 2;
    const int hard = 3;

    float timer;
    bool finish;


    private void Awake()
    {
        score = 0;
        finish = false;


        switch (LevManeger.Level)
        {
            case easy:
                minSpeed = easyMinSpeed;
                maxSpeed = easyMaxSpeed;
                wait = easyWaitTime;
                break;
            case normal:
                minSpeed = normalMinSpeed;
                maxSpeed = normalMaxSpeed;
                wait = normalWaitTime;

                break;
            case hard:
                minSpeed = hardMinSpeed;
                maxSpeed = hardMaxSpeed;
                wait = hardWaitTime;
                break;
        }

        minRad = minPizaRad;
        maxRad = maxPizaRad;
       // Debug.Log(maxRad);
        StartCoroutine("PizaInstant");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(finish);
        if(ReceiveEvent.btns[0] == false)
        {
            timer += Time.deltaTime;
            timerImage.fillAmount = 1 - (timer / maxTimer*3);
        }

        if(timer >= maxTimer || timerImage.fillAmount == 0)
        {
            Cursor.visible = true;
            finish = true;
            int lastHp = HPManeger.currentHP;
            lastHp = lastHp * 1000;
            ScoreAndHighScore.AddPoint(lastHp);
            //Debug.Log("‚¨‚í‚Á‚½‚í");
            SceneManager.LoadScene("ResultScene");
        }
    }

    IEnumerator PizaInstant()
    {
        var parent = this.transform;
        while (true)
        {
            if (Random.Range(1, 10) >= 5)
            {
                Instantiate(PizaR,parent);
            }
            else
            {
                Instantiate(PizaL,parent);
            }
            if (finish == true)
            {
                foreach (Transform child in this.gameObject.transform)
                {
                    Destroy(child.gameObject);
                }
                break;
            }
            yield return new WaitForSeconds(Random.Range(insMinSpeed,insMaxSpeed));
        }

        

    }
}
