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
    /// ���� ���� �ð� �ʱ�ȭ
    /// </summary>
    public void ResetTimer() {
        timerGoing = false;
        elapsedTime = 0f;
        timerText.text = "�ð�: 00:00.00";
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
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "�ð�: " + timePlaying.ToString("mm':'ss'.'ff");
            timerText.text = timePlayingStr;
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
        return elapsedTime;
    }

    #endregion
}
