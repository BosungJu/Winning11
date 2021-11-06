using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour, IPointerDownHandler
{
    public Text remainingTime;
    public Text resultText;
    public Text bestPlayer;
    public Timer timer;

    public void OnPointerDown(PointerEventData eventData)
    {
        SceneChanger.instance.ChangeScene("Lobby");
    }

    private void OnEnable()
    {
        remainingTime.text = "Remaining Time: " + timer.GetElapsedTime().ToString();
        resultText.text = "Result: " + "¼º°ø";
        bestPlayer.text = "";
    }
}
