using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer {

    #region Global Variables

    private Text timerText;
    private TimeSpan timePlaying;
    private float elapsedTime;
    private bool timerGoing;

    #endregion

    #region Init

    public Timer(Text timerText) {
        this.timerText = timerText;
    }

    #endregion

    #region Functions

    /// <summary>
    /// 게임 진행 시간 초기화
    /// </summary>
    public void ResetTimer() {
        timerGoing = false;
        elapsedTime = 0f;
        timerText.text = "시간: 00:00.00";
    }

    /// <summary>
    /// 게임 진행 시간 정지
    /// </summary>
    public void StopTimer() {
        timerGoing = false;
    }

    /// <summary>
    /// 시간 카운트업 실행하는 코루틴
    /// </summary>
    public IEnumerator StartTimerRoutine() {
        timerGoing = true;
        while (timerGoing) {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "시간: " + timePlaying.ToString("mm':'ss'.'ff");
            timerText.text = timePlayingStr;
            yield return null;
        }
        yield break;
    }

    #endregion

    #region Getters

    /// <summary>
    /// 게임 진행 시간 가져오기
    /// </summary>
    public float GetElapsedTime() {
        return elapsedTime;
    }

    #endregion
}
