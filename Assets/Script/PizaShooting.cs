using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizaShooting : MonoBehaviour
{
    [SerializeField] GameObject piza;
    [SerializeField] GameObject assistant1;
    [SerializeField] GameObject assistant2;
    Vector3 offset;
    Vector3 target;
    float deg;
    bool finish;


    // Start is called before the first frame update
    void Start()
    {
        SetTarget(assistant1.transform.position, assistant2.transform.position);
        SetTarget(assistant2.transform.position, assistant1.transform.position);
        SetTarget(assistant1.transform.position, assistant2.transform.position);
    }

    public void SetTarget(Vector3 target, Vector3 set)
    {
        
        transform.position = set;
        this.offset = transform.position;
        this.target = target - this.offset;
        this.deg = deg;
        
        StartCoroutine("ShootPiza");
    }

    IEnumerator ShootPiza()
    {
        finish = false;
        float b = Mathf.Tan(Random.Range(30,60) * Mathf.Deg2Rad);
        float a = (target.y - b * target.x) / (target.x * target.x);
        int sign = 1;
        Debug.Log(this.target.x);
        float target_x = this.target.x;
        if (this.target.x < 0 )
        {
            sign = -1;
        }
        for (float x = 0; x <= target_x * sign; x += 0.1f){
            Debug.Log("ì“®");
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
