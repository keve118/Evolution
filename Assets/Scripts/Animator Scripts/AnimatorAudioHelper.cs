using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimatorAudioHelper : MonoBehaviour
{
    [HideInInspector] public bool disableOnce;
    
    void PlaySoundOnce(AudioClip audioClip)
    {
        if (!disableOnce)
        {
            gameObject.GetComponentInParent<AudioSource>().PlayOneShot(audioClip);
        }
        else
        {
            disableOnce = false;
        }
    }

}
