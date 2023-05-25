using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizaShooting : MonoBehaviour
{
    [SerializeField] GameObject assistant1;
    [SerializeField] GameObject assistant2;
    
    Vector3 offset;
    Vector3 target;
    float deg;
    bool finish;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetTarget(assistant2.transform.position,assistant1.transform.position));
    }

    IEnumerator SetTarget(Vector3 pos1, Vector3 pos2)
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

            yield return new WaitForSeconds(PIzaManeger.wait);
            yield return ShootPiza();
        }
        yield return null;
        Destroy(this.gameObject); 
    }

    IEnumerator ShootPiza()
    {
        finish = false;
        float b = Mathf.Tan(Random.Range(PIzaManeger.minRad,PIzaManeger.maxRad) * Mathf.Deg2Rad);
        float a = (target.y - b * target.x) / (target.x * target.x);
        int sign = 1;
        Debug.Log(this.target.x);
        float target_x = this.target.x;
        if (this.target.x < 0 )
        {
            sign = -1;
        }
        float speed = Random.Range(LevManeger.minSpeed, LevManeger.maxSpeed);
        for (float x = 0; x <= target_x * sign; x += speed){
            float y = a * (x*sign) * (x*sign) + b * (x*sign);
            transform.position = new Vector3(x*sign, y*sign, 0) + offset;
            yield return null;
        }
        
        finish = true;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
