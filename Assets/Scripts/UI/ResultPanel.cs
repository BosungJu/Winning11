using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
    public Text resultText;
    public Image bestPlayerImage;
    public Text bestPlayerName;
    public Button mainBtn;

    private string[] resultTexts = { "Goal", "������", "�ð� ��"};

    private void ChangeLobby()
    {
        SceneChanger.instance.ChangeScene("Lobby");
    }

    private void Awake()
    {
        mainBtn.onClick.AddListener(() => ChangeLobby());
    }

    private void OnEnable()
    {
        resultText.text = resultTexts[ResultData.resultCode];

        if (ResultData.resultCode == 0)
        {
            if (ResultData.lastHitHomePlayer != null) 
            {
                bestPlayerName.text = ResultData.lastHitHomePlayer.GetName();
            }
            else
            {
                bestPlayerName.text = "���� ����";
            }
        }
        else
        {
            if (ResultData.lastHitAwayPlayer != null)
            {
                bestPlayerName.text = ResultData.lastHitAwayPlayer.GetName();
            }
            else
            {
                bestPlayerName.text = "�� ����";
            }
        }

        try
        {
            bestPlayerImage.sprite = Resources.Load<Sprite>(@"Images\" + (ResultData.resultCode == 0 ? "HomePlayer" : "AwayPlayerL" + ResultData.lastHitAwayPlayer.level + "Face"));
            // TODO image update
        }
        catch (Exception ex)
        {
            bestPlayerImage.sprite = null;
        }
    }
}
