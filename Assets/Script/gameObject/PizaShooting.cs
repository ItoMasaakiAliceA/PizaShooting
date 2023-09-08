using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizaShooting : MonoBehaviour
{
    [SerializeField] GameObject assistant1;
    [SerializeField] GameObject assistant2;
    [SerializeField] int startingHealth = 100; // ピザの HP の初期値
    private int score = 0; //スコア計算用変数
    public int currentHealth; // ピザの最新の HP

    Vector3 offset;
    Vector3 target;
    float deg;

    bool flash = false;
    float claSpeed = 0.1f;
    float cla;
    Color miko;
    



    // Start is called before the first frame update
    void Start()
    {
        miko = this.gameObject.GetComponent<Renderer>().material.color;
        currentHealth = startingHealth;
        //ピザのセット
        StartCoroutine(SetTarget(assistant2.transform.position,assistant1.transform.position));
    }

    //ピザの生存判定処理
    public IEnumerator SetTarget(Vector3 pos1, Vector3 pos2)
    {
        Vector3 set;
        Vector3 target;

        for (int i = 0; i < 3; i++)
        {
            set = pos1;
            target = pos2;
            if ((i&1) == 1)
            {
                set = pos2;
                target = pos1;
            }

            transform.position = set;
            this.offset = transform.position;
            this.target = target - this.offset;

            yield return new WaitForSeconds(PizaManeger.wait);
            yield return ShootPiza();
        }
        yield return null;
        Destroy(this.gameObject); 
    }

    //ピザを飛ばす処理
    IEnumerator ShootPiza()
    {
        
        float b = Mathf.Tan(UnityEngine.Random.Range(PizaManeger.minRad,PizaManeger.maxRad) * Mathf.Deg2Rad);
        float a = (target.y - b * target.x) / (target.x * target.x);
        int sign = 1;
        float target_x = this.target.x;
        if (this.target.x < 0 )
        {
            sign = -1;

        }
        float speed = UnityEngine.Random.Range(PizaManeger.minSpeed, PizaManeger.maxSpeed);
        float lamy = UnityEngine.Random.Range(-0.25f, 0.25f);
        for (float x = 0; x <= target_x * sign; x += speed){
            float y = a * (x*sign) * (x*sign) + b * (x*sign);
            transform.position = new Vector3(x*sign, y*sign, lamy) + offset;
            yield return null;
        }
        
       
    }


    public void PizaDamage(int damage)
    {
        currentHealth -= damage;
        
        if(currentHealth == 0)
        {
            score += 200;
            flash = true;
        }
        else if(currentHealth < 0)
        {
            score += 100;
        }
        else
        {
            score += 50;
            flash = true;
        }
        ScoreAndHighScore.AddPoint(score);
    }

    // Update is called once per frame
    void Update()
    {
        if( flash == true)
        {
            
            StartCoroutine(Display());
        }
    }

    IEnumerator Display()
    {
        for (int i = 0; i < 4; i++)
        {


            

            if (i % 2 == 0)
            {
                cla = 1;
                while (cla > 0f)
                {
                    cla -= claSpeed;
                    this.gameObject.GetComponent<Renderer>().material.color = new Color(miko.r,miko.g, miko.b, cla);
                    yield return null;

                }
            }
            else
            {
                cla = 0;
                while (cla < 1f)
                {
                    //Debug.Log("動けこのポンコツが！" + cla);
                    cla += claSpeed;
                    this.gameObject.GetComponent<Renderer>().material.color = new Color(miko.r, miko.g, miko.b, cla);
                    yield return null;

                }
            }

           
        }
        
        Destroy(this.gameObject);
    }
}
