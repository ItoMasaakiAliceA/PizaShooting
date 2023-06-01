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

        Debug.Log(gameAudio[0].volume);
        Debug.Log(gameAudio[1].volume);
    }


    public void Update()
    {

        gameAudio[0].volume = mSlider.value;
        gameAudio[1].volume = SESlider.value;

        // Escキーを押したとき
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameAudio[1].PlayOneShot(soundSE[1]);
            Debug.Log("なってるはず");
        }

        // マウスがクリックされたとき
        if (Input.GetMouseButtonDown(0))
        {
            // SceneがGamePlayManagerならこっち
            if (SceneManager.GetActiveScene().name == "GamePlayScene")
            {
                gameAudio[1].PlayOneShot(soundSE[2]);
            }
            // 違うならこっち
            else
            {
                gameAudio[1].PlayOneShot(soundSE[0]);
            }
        }

    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("bgm", mSlider.value);
        PlayerPrefs.SetFloat("se", SESlider.value);
        Debug.Log("save");
        Debug.Log(PlayerPrefs.GetFloat("bgm"));
        Debug.Log(PlayerPrefs.GetFloat("se"));
    }

}
