using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{
    [SerializeField] Slider mSetSlider;
    [SerializeField] Slider SESetSlider;
    [SerializeField] AudioClip[] soundSE;
    [SerializeField] AudioClip[] soundBGM;


    public static Slider SESlider;
    public static Slider mSlider;

    private float bgmVolume;
    private float seVolume;
    AudioSource[] gameAudio;

    void Start()
    {
        gameAudio = GetComponents<AudioSource>();
        mSlider = mSetSlider;
        SESlider = SESetSlider;

        float bgmVolume = PlayerPrefs.GetFloat("bgm");
        float seVolume = PlayerPrefs.GetFloat("se");

        mSlider.value = bgmVolume;
        SESlider.value = seVolume;

        gameAudio[0].volume = bgmVolume;
        gameAudio[1].volume = seVolume;

        PlayBGM();
    }


    public void Update()
    {
        gameAudio[0].volume = mSlider.value;
        gameAudio[1].volume = SESlider.value;
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("bgm", mSlider.value);
        PlayerPrefs.SetFloat("se", SESlider.value);
        Debug.Log("save");
        Debug.Log(PlayerPrefs.GetFloat("bgm"));
        Debug.Log(PlayerPrefs.GetFloat("se"));
    }

    public void PlayBGM()
    {
        //  タイトルシーンで流すやつ
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            gameAudio[0].PlayOneShot(soundBGM[0]);
        }

        if (SceneManager.GetActiveScene().name == "GamePlayScene")
        {
            gameAudio[0].PlayOneShot(soundBGM[1]);
        }

        if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            gameAudio[0].PlayOneShot(soundBGM[2]);
        }

        if (SceneManager.GetActiveScene().name == "ResultScene")
        {
            gameAudio[0].PlayOneShot(soundBGM[3]);
        }
        
        
    }

    public void PlayEsc()
    {
        // Escキーを押したとき
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameAudio[1].PlayOneShot(soundSE[1]);
            Debug.Log("なってるはず");
        }
    }

    public void PlayClick()
    {
        // SceneがGamePlayManagerならこっち
        if (SceneManager.GetActiveScene().name == "GamePlayScene")
        {
            // 鳴るシーンは後で、発射のとこにeventsで入れる
            gameAudio[1].PlayOneShot(soundSE[2]);
        }
        // 違うならこっち
        else
        {
            gameAudio[1].PlayOneShot(soundSE[0]);
        }
    }

    public void ClickRetry()
    {

    }



    // 爆発時に流れるよ
    public void Explosion()
    {
        gameAudio[1].PlayOneShot(soundSE[3]);
    }

    // 対象に当たったら流れるよ
    public void HitObject()
    {
        gameAudio[1].PlayOneShot(soundSE[4]);
    }

}
