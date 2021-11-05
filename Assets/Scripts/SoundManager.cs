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
    /// 개인 audioSource에서 SFX PlayOneShot()
    /// </summary>
    public void PlayOneShotHere(AudioSource audioSource, Sound name) {
        audioSource.PlayOneShot(soundDict[name], volDict[name]);
    }

    /// <summary>
    /// SoundManager의 sfxAudioSource에서 SFX PlayOneShot()
    /// </summary>
    public void PlayOneShotThere(Sound name) {
        sfxAudioSource.PlayOneShot(soundDict[name], volDict[name]);
    }

    /// <summary>
    /// pos에 PlayClipAtPoint()
    /// </summary>
    public void PlayClipAtPoint(Vector3 pos, Sound name) {
        AudioSource.PlayClipAtPoint(soundDict[name], pos);
    }

    /// <summary>
    /// SoundManager의 musicAudioSource에서 BGM Play()
    /// </summary>
    public void PlayMusic(Sound name) {
        musicAudioSource.Stop();
        musicAudioSource.clip = soundDict[name];
        musicAudioSource.volume = volDict[name];
        musicAudioSource.Play();
    }

    /// <summary>
    /// SoundManager의 ambientAudioSource에서 ambient 효과음 Play()
    /// </summary>
    public void PlayAmbient(Sound name) {
        ambientAudioSource.Stop();
        ambientAudioSource.clip = soundDict[name];
        ambientAudioSource.volume = volDict[name];
        ambientAudioSource.Play();
    }

    #endregion
}
