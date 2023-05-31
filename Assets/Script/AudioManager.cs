using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class AudioManager : MonoBehaviour
{
    [SerializeField] Slider mSetSlider;
    [SerializeField] Slider SESetSlider;
    [SerializeField] AudioClip sound1;

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameAudio[1].PlayOneShot(sound1);
            Debug.Log("‚È‚Á‚Ä‚é‚Í‚¸");
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
