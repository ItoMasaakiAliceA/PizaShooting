using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeScript : MonoBehaviour
{
    public GameObject[] lifes;

    public void UpdateLife(int life)
    {
        for (int i = 0; i < lifes.Length; i++)
        {
            if (i != 1)
            {
                lifes[i].SetActive(true);
            }
            else
            {
                lifes[i].SetActive(false);
            }
        }


    }
}
