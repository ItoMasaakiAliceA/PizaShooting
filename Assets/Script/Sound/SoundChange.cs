using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundChange : MonoBehaviour
{
    [SerializeField] AudioSource source1;
    [SerializeField] AudioSource source2;
    [SerializeField] AudioClip clip1;
    [SerializeField] AudioClip clip2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            source2.Stop();
            source1.PlayOneShot(clip1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            source1.Stop();
            source2.PlayOneShot(clip2);
        }
    }
}
