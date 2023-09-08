using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndHighScore : MonoBehaviour
{
    // スコアを表示するUIの取得用
    [SerializeField]
    Text scoreTx;
    [SerializeField]
    Text highScoreTx;

    public static Text scoreText;


    // スコアのカウント用
    public static int score;

    // ハイスコアのカウント用
    private static int highScore;
    //private static bool New = false;



    public static int GetScore()
    {
        //スコア送りまーす
        return score;
    }

    /*public static bool GetNew()
    {
        return New;
    }*/

    public static int GetHighScore()
    {
        //ハイスコア送りまーす
        return highScore;
    }

    void Start()
    {
        scoreText = scoreTx;
        Initialize();
    }

    // ゲーム開始前の状態に戻す
    private void Initialize()
    {
        // スコアを0に戻す
        score = 0;
        // highScoreKeyの値で保存されているハイスコアを検索して取得する。保存されてなければ0を取得する。
        highScore = PlayerPrefs.GetInt("highScore", 0);
        //Debug.Log(highScore);
        highScoreTx.text = "HighScore:" + highScore.ToString();
    }

    // ポイントの追加。修飾子をpublicにしているので外部より参照できるメソッドになっている
    public static void AddPoint(int point)　　　　　　//　外部より受け取ったint型の引数をpointとして受け取る
    {
        score += point;
       // Debug.Log(score);                       // ここで確認すると、ブロックからの情報が届いているか確認できる。表示されなければ届いていないということになる。

        // スコアがハイスコアより大きくなれば、ハイスコアを更新する
        if (highScore < score)
        {
            highScore = score;
           // New = true;

           // Debug.Log(highScore);               // ハイスコアの更新が正常に行われたか確認できる
        }

        // ゲーム画面上のスコアとハイスコアの表示を更新する
        DisplayScores();
        
    }

    // ゲーム画面上のスコアとハイスコアの表示を更新する
    public  static void DisplayScores()
    {
        // 現在のスコアとハイスコアを画面に表示する
        //Debug.Log(score.ToString());
        scoreText.text = "Score:" + score.ToString();

    }

    // ハイスコアの保存
    /*public void Save(int highScore)
    {
        // ハイスコアを保存する
        PlayerPrefs.SetInt("highScore", highScore);
        PlayerPrefs.Save();

        // ゲーム開始前の状態に戻す
        Initialize();
        Debug.Log("とんでもねぇ待ってたんだ");
    }*/


}
