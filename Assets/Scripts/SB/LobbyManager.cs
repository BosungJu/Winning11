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
    }

    #endregion

    #region Functions

    public void StartGame(string scene) {
        SceneChanger.instance.ChangeScene(scene);
    }

    #endregion
}
