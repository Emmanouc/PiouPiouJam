using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in Sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.Clip;

            s.source.volume = s.Volume;
            s.source.pitch = s.Pitch;

        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(Sounds, sound => sound.Name == name);
        s.source.Play();
    }
}
