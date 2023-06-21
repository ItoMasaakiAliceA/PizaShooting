using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizaShooting : MonoBehaviour
{
    [SerializeField] GameObject assistant1;
    [SerializeField] GameObject assistant2;
    [SerializeField] int startingHealth = 100; // ピザの HP の初期値
    [SerializeField] int pizaPoint = 100;
    public int currentHealth; // ピザの最新の HP

    Vector3 offset;
    Vector3 target;
    float deg;
    bool finish;// ピザ消滅判定

    


    // Start is called before the first frame update
    void Start()
    {
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
        finish = false;
        float b = Mathf.Tan(Random.Range(PizaManeger.minRad,PizaManeger.maxRad) * Mathf.Deg2Rad);
        float a = (target.y - b * target.x) / (target.x * target.x);
        int sign = 1;
        float target_x = this.target.x;
        if (this.target.x < 0 )
        {
            sign = -1;
        }
        float speed = Random.Range(PizaManeger.minSpeed, PizaManeger.maxSpeed);
        for (float x = 0; x <= target_x * sign; x += speed){
            float y = a * (x*sign) * (x*sign) + b * (x*sign);
            transform.position = new Vector3(x*sign, y*sign, 0) + offset;
            yield return null;
        }
        
        finish = true;
    }

    public void PizaDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            PizaManeger.score += pizaPoint;
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
