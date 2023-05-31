using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Slider mSetSlider;
    [SerializeField] Slider SESetSlider;
    [SerializeField] AudioClip sound1;

    public static TextMeshProUGUI levelText;
    public static Slider SESlider;
    public static Slider mSlider;

    AudioSource[] GameAudio;
    bool check;
    public static float timer;


    // Start is called before the first frame update
    void Start()
    {
        GameAudio = GetComponents<AudioSource>();
        mSlider = mSetSlider;
        SESlider = SESetSlider;

        GameAudio[0].volume = mSlider.value;
        GameAudio[1].volume = mSlider.value;
        GameAudio[2].volume = SESlider.value;
        Debug.Log(GameAudio[0].volume);
    }
}
