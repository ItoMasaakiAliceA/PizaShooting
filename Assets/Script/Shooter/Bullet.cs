using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   
       public void Shoot(Vector3 dir)
       {
           GetComponent<Rigidbody>().AddForce(dir);
       }
}