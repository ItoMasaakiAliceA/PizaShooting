using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PizaHit : MonoBehaviour
{
   // public Text scoreText; //Textópïœêî
   
    //ScoreAndHighScore scoreUp;

   
    //pizaÇ∆BulletÇÃè’ìÀÇ≈pointÇ+100Ç∑ÇÈ

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
