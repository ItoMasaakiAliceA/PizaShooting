using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManeger : MonoBehaviour
{
    [SerializeField] float timeBetweenClicks = 0.15f;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Slider mSetSlider;
    [SerializeField] Slider SESetSlider;
    [SerializeField] AudioClip sound1;

    public static TextMeshProUGUI levelText;
    public static Slider SESlider;
    public static Slider mSlider;

    AudioSource[] titleAudio;
    bool check;
    public static float timer;
    

    // Start is called before the first frame update
    void Start()
    {
        titleAudio = GetComponents<AudioSource>();
        mSlider = mSetSlider;
        SESlider = SESetSlider;

        titleAudio[0].volume = mSlider.value;
        titleAudio[1].volume = SESlider.value;


        levelText = text;
        TitleManeger.levelText.text = "EASY";
        levelText.color = new Color(0f, 1f, 0.196f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        CheckBtn(ReceiveEvent.btns);
        titleAudio[0].volume = mSlider.value;
        titleAudio[1].volume = SESlider.value;
        //Debug.Log("TitleCheck = " + check);

        if (Input.GetMouseButtonDown(0)&& check == false && timer >= timeBetweenClicks &&
            Time.timeScale != 0) {
            Debug.Log("Start");
            SceneManager.LoadScene(1);
        }
        if (Input.GetMouseButtonDown(0))
        {
            titleAudio[1].PlayOneShot(sound1);
        }

        timer += Time.deltaTime;
    }

    void CheckBtn(bool[] btns)
    {
        check = false;
        foreach (bool btn in btns)
        {
            if (btn == true)
            {
                check = true;
            }
        }

    }
}
