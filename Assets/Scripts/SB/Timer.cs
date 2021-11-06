using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer {

    #region Global Variables

    private Text timerText;
    private TimeSpan timePlaying;
    private float currentTime;
    private bool timerGoing;
    public Action timeOutEvent;

    #endregion

    #region Init

    public Timer(Text timerText) {
        this.timerText = timerText;
    }

    #endregion

    #region Functions

    /// <summary>
    /// ���� ���� �ð� �ʱ�ȭ
    /// </summary>
    public void ResetTimer() {
        timerGoing = false;
        currentTime = 11f;
        timerText.text = "11.00";
    }

    /// <summary>
    /// ���� ���� �ð� ����
    /// </summary>
    public void StopTimer() {
        timerGoing = false;
    }

    /// <summary>
    /// �ð� ī��Ʈ�� �����ϴ� �ڷ�ƾ
    /// </summary>
    public IEnumerator StartTimerRoutine() {
        timerGoing = true;
        while (timerGoing) {
            currentTime -= Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(currentTime);
            string timePlayingStr = timePlaying.ToString("ss'.'ff");
            timerText.text = timePlayingStr;
            
            if (timePlaying.TotalSeconds < 0)
            {
                ResultData.resultCode = 2;
                timeOutEvent();
            }

            yield return null;
        }
        yield break;
    }

    #endregion

    #region Getters

    /// <summary>
    /// ���� ���� �ð� ��������
    /// </summary>
    public float GetElapsedTime() {
        return currentTime;
    }

    #endregion
}
