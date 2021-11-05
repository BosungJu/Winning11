using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager> {

    #region Global Variables

    [Header("REFERENCES")]
    [SerializeField]
    private Text timerText;
    private Timer timer;

    #endregion

    #region Main

    void Awake() {
        timer = new Timer(timerText);
        //GameManager.instance.startGameEvent += StartTimer;
    }

    void Start() {
        StartTimer();
    }

    #endregion

    #region Functions

    private void StartTimer() {
        timer.ResetTimer();
        StartCoroutine(timer.StartTimerRoutine());
    }

    #endregion
}
