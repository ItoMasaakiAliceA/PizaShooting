using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PizaHit : MonoBehaviour
{
   // public Text scoreText; //Text用変数
   
    //ScoreAndHighScore scoreUp;

   
    //pizaとBulletの衝突でpointを+100する

    void OnCollisionEnter(Collision collision)

    {

        string yourTag = collision.gameObject.tag;
        //Debug.Log(yourTag);


        if (yourTag == "Piza")

        {

            
            collision.gameObject.GetComponent<PizaShooting>().PizaDamage(50);
            //Debug.Log(score);
           
            Destroy(gameObject);

        }

       

    }



   /* void SetScore()

    {

        scoreText.text = string.Format("Score:{0}", score);

    }*/



}
