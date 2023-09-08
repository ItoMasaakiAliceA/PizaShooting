using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject tmtPre;
    public GameObject grpPre;
    public GameObject oriPre;
    public GameObject sarPre;
    public GameObject uwiPre;
    private bool Switch;
    float koyori = 0;
    public GameObject Prefab;
    GameObject Bullets;

    private void Start()
    {
        Switch = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Switch = !Switch;
        }

        if (Switch == true) {
            if (Input.GetMouseButton(0))
            {
                if (koyori <= 0)
                {
                    float Aqua = Random.value;
                    //Debug.Log(Aqua);
                    if (Aqua < 0.25)
                    {
                        //Debug.Log("トマトやんけ！");
                        Prefab = tmtPre;
                    }
                    else if (Aqua < 0.5)
                    {
                        // Debug.Log("ピーマンじゃい！");
                        Prefab = grpPre;
                    }
                    else if (Aqua < 0.75)
                    {
                        //Debug.Log("オリー");
                        Prefab = oriPre;
                    }
                    else if (Aqua < 0.995)
                    {
                        //Debug.Log("サラミィ");
                        Prefab = sarPre;
                    }
                    else
                    {
                        //Debug.Log("あ、レアものだ");
                        Prefab = uwiPre;
                    }
                    //Debug.Log(Prefab);
                    Bullets = Instantiate(Prefab) as GameObject;

                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    Vector3 worldDir = ray.direction;
                    worldDir.y += 0.3f;
                    Bullets.GetComponent<Bullet>().Shoot(
                        worldDir.normalized * 1750);
                    koyori = 15;
                }
            }
            koyori -= 1;
        }
        Destroy(Bullets, 2.0f);
    }
}