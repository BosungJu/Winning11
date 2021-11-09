using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour {

    public GameObject popUp;
    public GameObject setting;
    public GameObject logo;
    public GameObject particleObj;

    #region Main

    private void Awake() {
        Time.timeScale = 1;
    }

    void Start() {
        SoundManager.instance.PlayBGM(Sound.Bgm);
        //SoundManager.instance.ChangeBounceVol(0.6f);
    }

    #endregion

    #region Functions

    public void StartGame(string scene) {
        SceneChanger.instance.ChangeScene(scene);
        SoundManager.instance.PlayOneShotThere(Sound.Button);
    }

    public void DisplayPopup()
    {
        popUp.SetActive(true);
        logo.SetActive(false);
        particleObj.SetActive(false);
    }

    public void DisplaySetting()
    {
        if (!setting.activeSelf)
        {
            setting.SetActive(true);
            logo.SetActive(false);
            particleObj.SetActive(false);
        }
        else
        {
            setting.SetActive(false);
            logo.SetActive(true);
            particleObj.SetActive(true);
        }
    }

    #endregion
}
