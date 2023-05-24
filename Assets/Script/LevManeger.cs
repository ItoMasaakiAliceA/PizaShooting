using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevManeger : MonoBehaviour
{
    public static int Level;
    public const int easy = 1;
    const int normal = 2;
    const int hard = 3;

    [SerializeField] GameObject manualPanel;
    [SerializeField] GameObject easyPanel;
    [SerializeField] GameObject normalPanel;
    [SerializeField] GameObject hardPanel;
    [SerializeField] float easyMinSpeed = 0.02f;
    [SerializeField] float easyMaxSpeed = 0.04f;
    [SerializeField] float normalMinSpeed = 0.05f;
    [SerializeField] float normalMaxSpeed = 0.1f;
    [SerializeField] float hardMinSpeed = 0.1f;
    [SerializeField] float hardMaxSpeed = 0.2f;

    public static float minSpeed;
    public static float maxSpeed;

    //[SerializeField] TextMeshProUGUI levelText;
    // Start is called before the first frame update

    private void Awake()
    {
        minSpeed = easyMinSpeed;
        maxSpeed = easyMaxSpeed;
    }

    public void LevelText()
    {
        switch (Level)
        {
            case easy:
                TitleManeger.levelText.text = "EASY";
                TitleManeger.levelText.color = new Color(0f, 1f, 0.2f, 1f);
                minSpeed = easyMinSpeed;
                maxSpeed = easyMaxSpeed;
                break;
            case normal:
                TitleManeger.levelText.text = "NORMAL";
                TitleManeger.levelText.color = new Color(1f, 1f, 0f, 1f);
                minSpeed = normalMinSpeed;
                maxSpeed = normalMaxSpeed;
                break;
            case hard:
                TitleManeger.levelText.text = "HARD";
                TitleManeger.levelText.color = new Color(1f, 0f, 0f, 1f);
                minSpeed = hardMinSpeed;
                maxSpeed = hardMaxSpeed;
                Debug.Log(hardMinSpeed);
                Debug.Log(hardMaxSpeed);
                break;
        }
    }

    public void setup()
    {
        easyPanel.SetActive(true);
        normalPanel.SetActive(true);
        hardPanel.SetActive(true);

    }

    void remove()
    {
        easyPanel.SetActive(false);
        normalPanel.SetActive(false);
        hardPanel.SetActive(false);
        TitleManeger.timer = 0f;
        LevelText();
    }

    public void SetEasy()
    {
        Level = easy;
        ReceiveEvent.btns[2] = false;
        manualPanel.SetActive(ReceiveEvent.btns[2]);
        remove();
    }

    public void SetNormal()
    {
        Level = normal;
        ReceiveEvent.btns[2] = false;
        manualPanel.SetActive(ReceiveEvent.btns[2]);
        remove();
    }

    public void SetHard()
    {
        Level = hard;
        ReceiveEvent.btns[2] = false;
        manualPanel.SetActive(ReceiveEvent.btns[2]);
        remove();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
