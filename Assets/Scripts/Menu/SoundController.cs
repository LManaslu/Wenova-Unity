using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    public static SoundController instance;
    [SerializeField] AudioClip menuMusic;
    [SerializeField] AudioClip[] levelsMusics;
    [SerializeField] AudioSource source;

    void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(this);
        } else {
            Destroy(gameObject);
            return;
        }
    }

    static public void PlayMenuMusic() {
        if(instance != null) {
            if(instance.source != null && instance.source.clip != instance.menuMusic) {
                instance.source.Stop();
                instance.source.clip = instance.menuMusic;
                instance.source.Play();
            }
        }
    }

    static public void PlayLevelMusic(int clipCount) {
        if(instance != null) {
            if(instance.source != null) {
                instance.source.Stop();
                instance.source.clip = instance.levelsMusics[clipCount];
                instance.source.Play();
            }
        }
    }
}
