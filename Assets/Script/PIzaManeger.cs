using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PizaManeger : MonoBehaviour
{
    [SerializeField] float waitTime = 0.4f;
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
    [SerializeField] float maxTimer = 10f;


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

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        finish = false;
    }

    private void Awake()
    {


        switch (LevManeger.Level)
        {
            case easy:
                minSpeed = easyMinSpeed;
                maxSpeed = easyMaxSpeed;
                break;
            case normal:
                minSpeed = normalMinSpeed;
                maxSpeed = normalMaxSpeed;

                break;
            case hard:
                minSpeed = hardMinSpeed;
                maxSpeed = hardMaxSpeed;

                break;
        }

        wait = waitTime;
        minRad = minPizaRad;
        maxRad = maxPizaRad;

        StartCoroutine("PizaInstant");
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        timerImage.fillAmount = 1-(timer / maxTimer);

        Debug.Log(score);
        if(timer >= maxTimer || Time.timeScale == 0)
        {
            finish = true;
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
