using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour {

    #region Main

    void Start() {
        //SoundManager.instance.PlayMusic(Sound.MusicLobby);
    }

    #endregion

    #region Functions

    public void StartGame(string scene) {
        SceneChanger.instance.ChangeScene(scene);
    }

    #endregion
}
