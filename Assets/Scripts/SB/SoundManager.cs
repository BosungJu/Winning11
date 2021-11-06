using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sound {
    Bgm, Button, Dice, Enemy1, Enemy2, Enemy3, Player, Wall, Aiming, Shoot, Fail, Win
}

public class SoundManager : Singleton<SoundManager> {

    #region Global Variables

    [Header("REFERENCES")]
    [SerializeField]
    private AudioSource bgmAudioSource;
    [SerializeField]
    private AudioSource aimAudioSource;
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
        if (GameObject.FindGameObjectsWithTag("SoundManager").Length > 1) {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
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
    /// SoundManager�� bgmAudioSource���� BGM Play()
    /// </summary>
    public void PlayBGM(Sound name) {
        bgmAudioSource.Stop();
        bgmAudioSource.clip = soundDict[name];
        bgmAudioSource.volume = volDict[name];
        bgmAudioSource.Play();
    }

    /// <summary>
    /// SoundManager�� bgmAudioSource���� BGM Stop()
    /// </summary>
    public void StopBGM() {
        bgmAudioSource.Stop();
    }

    /// <summary>
    /// SoundManager�� aimAudioSource���� Aiming ȿ���� Play()
    /// </summary>
    public void PlayAiming() {
        aimAudioSource.Stop();
        aimAudioSource.clip = soundDict[Sound.Aiming];
        aimAudioSource.volume = volDict[Sound.Aiming];
        aimAudioSource.Play();
    }

    /// <summary>
    /// SoundManager�� aimAudioSource���� Aiming ȿ���� Stop()
    /// </summary>
    public void StopAiming() {
        aimAudioSource.Stop();
    }

    /// <summary>
    /// SoundManager�� ambientAudioSource���� ambient ȿ���� Play()
    /// </summary>
    public void PlayAmbient(Sound name) {
        aimAudioSource.Stop();
        aimAudioSource.clip = soundDict[name];
        aimAudioSource.volume = volDict[name];
        aimAudioSource.Play();
    }

    public void ChangeBounceVol(float volume) {
        volDict[Sound.Player] = volume;
        volDict[Sound.Enemy1] = volume;
        volDict[Sound.Enemy2] = volume;
        volDict[Sound.Enemy3] = volume;
        volDict[Sound.Wall] = volume;
    }

    /// <summary>
    /// Get aimAudioSource
    /// </summary>
    public AudioSource GetAimAudioSource() {
        return aimAudioSource;
    }

    #endregion
}
