using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        //play background music from start
        Play("Background");
    }

    public void Play(string name)
    {
        //finding the sound clip to play (in other scripts)
        Sound soundToPlay = Array.Find(sounds, sound => sound.name == name);
       
        if(soundToPlay == null) //soundclip name dosen't exist
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        soundToPlay.source.Play();
    }

    public void Stop(string name)
    {
        //finding the sound clip to play (in other scripts)
        Sound soundToStop = Array.Find(sounds, sound => sound.name == name);

        if (soundToStop == null) //soundclip name dosen't exist
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        soundToStop.source.Stop();
    }
}
