using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour {

    #region Main

    private void Awake() {
        Time.timeScale = 1;
    }

    void Start() {
        SoundManager.instance.PlayBGM(Sound.Bgm);
        SoundManager.instance.ChangeBounceVol(1);
    }

    #endregion

    #region Functions

    public void StartGame(string scene) {
        SceneChanger.instance.ChangeScene(scene);
        SoundManager.instance.PlayOneShotThere(Sound.Button);
    }

    #endregion
}
