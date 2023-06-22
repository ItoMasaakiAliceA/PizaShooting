using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManeger : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] int HP = 3;
    public static int currentHP;
    public static int maxHP;

    public static List<Image> HPs;
    Image hp;
    Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        maxHP = HP;
        parent = this.transform;
        Vector3 pos = parent.position;
        HPs = new List<Image>(maxHP);
        currentHP = maxHP;

        for (int i = 0; i < maxHP; i++)
        {
            
            hp = Instantiate(image, parent);
            hp.transform.position = pos;
            pos.x += 35;
            HPs.Add(hp);
        }
    }

    // HP•\Ž¦
    public static void UpdateHP()
    {
        for (int i = maxHP; i > currentHP; i--)
        {
            HPs[i - 1].color = new Color(1, 1, 1, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
