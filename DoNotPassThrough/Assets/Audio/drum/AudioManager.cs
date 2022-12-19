using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

    public Sound act;

    private AudioSource PlayerAudioSource;

    public AudioClip[] sfxClip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound item in sounds)
        {
            item.source = gameObject.AddComponent<AudioSource>();
            item.source.clip = item.clip;

            item.source.volume = item.volume;
            item.source.pitch = item.pitch;
            item.source.loop = item.Loop;
        }
        act = sounds[0];
    }

    private void Start()
    {
       Play("Main theme");
    }


    public void PlaySFX(int i) {
        //Player.instance.GetComponent<AudioSource>().PlayOneShot(sfxClip[i]);
    }

    public void Play(string name)
    {
        act = Array.Find(sounds, x => x.name == name);
        if (act == null)
        {
            Debug.Log("Sound" + name + "was not found");
            return;
        }

       // Player.instance.GetComponent<AudioSource>().clip = act.clip;
       // Player.instance.GetComponent<AudioSource>().volume = act.volume;
      //  Player.instance.GetComponent<AudioSource>().loop = act.Loop;


       // Player.instance.GetComponent<AudioSource>().Play();

    }

}
