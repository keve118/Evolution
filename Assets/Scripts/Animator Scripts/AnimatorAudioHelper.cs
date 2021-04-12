using UnityEngine;

/// <summary>
/// This is a helper class that is responsible for responding 
/// to an event set in Unitys animator components keyframe window.
/// </summary>
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
