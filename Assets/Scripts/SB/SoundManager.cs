using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sound {
    AmbientCrowd, MusicLobby, MusicGame, Shoot, Goal,
}

public class SoundManager : Singleton<SoundManager> {

    #region Global Variables

    [Header("REFERENCES")]
    [SerializeField]
    private AudioSource musicAudioSource;
    [SerializeField]
    private AudioSource ambientAudioSource;
    [SerializeField]
    private AudioSource sfxAudioSource;

    [System.Serializable]
    public class SoundGroup {
        public Sound name;
        public AudioClip clip;
        public float volume;
    }
    [Header("SOUNDS LIST")]
    [SerializeField]
    public SoundGroup[] sounds;
    public Dictionary<Sound, AudioClip> soundDict = new Dictionary<Sound, AudioClip>();
    public Dictionary<Sound, float> volDict = new Dictionary<Sound, float>();

    #endregion

    #region Main

    void Awake() {
        foreach (SoundGroup sound in sounds) {
            soundDict[sound.name] = sound.clip;
            volDict[sound.name] = sound.volume;
        }
    }

    #endregion

    #region Functions

    /// <summary>
    /// ���� audioSource���� SFX PlayOneShot()
    /// </summary>
    public void PlayOneShotHere(AudioSource audioSource, Sound name) {
        audioSource.PlayOneShot(soundDict[name], volDict[name]);
    }

    /// <summary>
    /// SoundManager�� sfxAudioSource���� SFX PlayOneShot()
    /// </summary>
    public void PlayOneShotThere(Sound name) {
        sfxAudioSource.PlayOneShot(soundDict[name], volDict[name]);
    }

    /// <summary>
    /// pos�� PlayClipAtPoint()
    /// </summary>
    public void PlayClipAtPoint(Vector3 pos, Sound name) {
        AudioSource.PlayClipAtPoint(soundDict[name], pos);
    }

    /// <summary>
    /// SoundManager�� musicAudioSource���� BGM Play()
    /// </summary>
    public void PlayMusic(Sound name) {
        musicAudioSource.Stop();
        musicAudioSource.clip = soundDict[name];
        musicAudioSource.volume = volDict[name];
        musicAudioSource.Play();
    }

    /// <summary>
    /// SoundManager�� ambientAudioSource���� ambient ȿ���� Play()
    /// </summary>
    public void PlayAmbient(Sound name) {
        ambientAudioSource.Stop();
        ambientAudioSource.clip = soundDict[name];
        ambientAudioSource.volume = volDict[name];
        ambientAudioSource.Play();
    }

    #endregion
}
