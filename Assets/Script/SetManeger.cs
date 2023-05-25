using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetManeger : MonoBehaviour
{

    [SerializeField] Slider mSlider;
    [SerializeField] Slider SESlider;

    // Start is called before the first frame update
    void Start()
    {
        mSlider.value = TitleManeger.mSlider.value;
        SESlider.value = TitleManeger.SESlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        TitleManeger.mSlider.value = mSlider.value;
        TitleManeger.SESlider.value = SESlider.value;
    }
}
