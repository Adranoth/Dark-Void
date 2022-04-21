using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{

    public Sons[] son;
    public static AudioManager instance;
    public bool enCombatMusique;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach(Sons audio in son)
        {
            audio.source = gameObject.AddComponent<AudioSource>();
            audio.source.clip = audio.clip;
            audio.source.volume = audio.volume;
            audio.source.pitch = audio.pitch;
            audio.source.loop = audio.loop;
        }
    }

    private void Start()
    {
        Play("station_spatial");
    }
    public void Play (string nom)
    {
       Sons audio = Array.Find(son, sons => sons.nom == nom);
        if (audio == null)
        {
            return;
        }
        audio.source.Play();
    }

    public IEnumerator StartFade(string nom, float duration, float targetVolume)
    {
        Sons audio = Array.Find(son, sons => sons.nom == nom);

        float currentTime = 0;
        float start = audio.source.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audio.source.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }

    public void Stop(string nom)
    {
        Sons audio = Array.Find(son, sons => sons.nom == nom);
        if (audio == null)
        {
            return;
        }
        audio.source.Stop();
    }
}