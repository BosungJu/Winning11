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

    private string[] resultTexts = { "Goal", "Line Out", "Time Out"};

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
        bestPlayerName.text = ResultData.resultCode == 0 ? ResultData.lastHitHomePlayer.GetName() : ResultData.lastHitAwayPlayer.GetName();
        bestPlayerImage.sprite = Resources.Load<Sprite>(@"Images\" + (ResultData.resultCode == 0 ? "HomePlayer" : "AwayPlayerL" + ResultData.lastHitAwayPlayer.level + "Face"));
        // TODO image update
    }
}
