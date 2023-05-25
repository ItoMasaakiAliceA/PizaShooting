using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PIzaManeger : MonoBehaviour
{
    [SerializeField] float waitTime = 0.4f;
    [SerializeField] float minPizaSpeed = 0.05f;
    [SerializeField] float maxPizaSpeed = 0.2f;
    [SerializeField] int minPizaRad = 30;
    [SerializeField] int maxPizaRad = 60;

    [SerializeField] GameObject PizaR;
    [SerializeField] GameObject PizaL;

    public static float wait;
    public static float minSpeed;
    public static float maxSpeed;

    public static float minRad;
    public static float maxRad;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void Awake()
    {
        

        wait = waitTime;
        minSpeed = minPizaSpeed;
        maxSpeed = maxPizaSpeed;
        minRad = minPizaRad;
        maxRad = maxPizaRad;

        Instantiate(PizaR);
        Instantiate(PizaL);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(0);
        }
       
    }
}
