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
    [SerializeField]
    private GameObject pausePanel;
    public Timer timer;

    [SerializeField]
    private GameObject resultPanel;

    #endregion

    #region Main

    void Awake() {
        Time.timeScale = 1;
        timer = new Timer(timerText);
        GameManager.instance.endGameEvnent += DisplayResult;
        timer.timeOutEvent += DisplayResult;
    }

    void Start() {
        if (pausePanel.activeSelf) {
            pausePanel.SetActive(false);
        }

        if (resultPanel.activeSelf)
        {
            resultPanel.SetActive(false);
        }

        StartTimer();
    }

    #endregion

    #region Functions

    private void StartTimer() {
        timer.ResetTimer();
        StartCoroutine(timer.StartTimerRoutine());
    }
    
    public void PauseGame() {
        timer.StopTimer();
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ResumeGame() {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(timer.StartTimerRoutine());
    }

    public void DisplayResult()
    {
        timer.StopTimer();
        Time.timeScale = 0;
        resultPanel.SetActive(true);
    }

    #endregion
}
