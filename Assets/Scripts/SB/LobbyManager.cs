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

    public void LoadScene(int scene) {
        StartCoroutine(LoadSceneRoutine());
    }

    private IEnumerator LoadSceneRoutine() {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
        while (!asyncLoad.isDone) {
            yield return null;
        }
        yield break;
    }

    #endregion
}