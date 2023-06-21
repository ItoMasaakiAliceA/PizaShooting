using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UncleManeger : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Image warningImage;
    [SerializeField] Texture uncleTexture;
    [SerializeField] Texture angryUncleTexture;
    [SerializeField] GameObject uncleObj;
    [SerializeField] float uncleComeMinTimer = 5f;
    [SerializeField] float uncleComeMaxTimer = 8f;
    [SerializeField] float uncleWaitMinTimer = 3f;
    [SerializeField] float uncleWaitMaxTimer = 5f;
    [SerializeField] float warningTimer = 1f;


    float comeTimer;
    float waitTimer;
    public static Texture uncleTex;
    public static Texture angryUncleTex;
    public static Animator anim;
    public static float uncleTimer;
    public static GameObject uncle;
    public static bool uncleAng;

    // Start is called before the first frame update
    void Awake()
    {
        comeTimer = Random.Range(uncleComeMinTimer, uncleComeMaxTimer);
        waitTimer = comeTimer + Random.Range(uncleWaitMinTimer, uncleWaitMaxTimer);
        uncle = uncleObj;
        uncleTex = uncleTexture;
        angryUncleTex = angryUncleTexture;
        anim = animator;
        UncleReset();
    }

    // Update is called once per frame
    void Update()
    {
        ReceiveEvent.CheckBtn(ReceiveEvent.btns);
        if (ReceiveEvent.check == false)
        {
            uncleTimer += Time.deltaTime;
            ReceiveEvent.timer += Time.deltaTime;
        }
        if (ReceiveEvent.check == false)
        {
            if (uncleTimer >= comeTimer && anim.GetBool("Come") == false)
            {
                anim.SetBool("Come", true);
                warningImage.color = new Color(1, 0, 0, 0);
            }
            else if (uncleTimer >= comeTimer - warningTimer && anim.GetBool("Come") == false)
            {

                warningImage.color = new Color(1, 0, 0, 1);
            }
            if (uncleTimer >= waitTimer && anim.GetBool("Come") == true)
            {
                anim.SetBool("Back", true);
                comeTimer = Random.Range(uncleComeMinTimer, uncleComeMaxTimer);
                waitTimer = comeTimer + Random.Range(uncleWaitMinTimer, uncleWaitMaxTimer);
            }
        }

        

    }

    public static void UncleJudge()
    {
        if (Input.GetMouseButton(0) && uncleAng == false && ReceiveEvent.check == false
            && ReceiveEvent.timer > 0.15f && Time.timeScale != 0)
        {
            uncle.GetComponent<MeshRenderer>().material.mainTexture = angryUncleTex;
            uncleAng = true;
            if(HPManeger.currentHP > 0)
            {
                HPManeger.currentHP--;
                HPManeger.UpdateHP();
            }
        }
    }

    public static void UncleReset()
    {
        anim.SetBool("Back", false);
        anim.SetBool("Come", false);
        uncleTimer = 0;
        uncleAng = false;
        uncle.GetComponent<MeshRenderer>().material.mainTexture = UncleManeger.uncleTex;
    }

    
}
