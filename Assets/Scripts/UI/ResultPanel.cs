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

    private string[] resultTexts = { "Victory!", "Out!", "Time's Up!"};

    private string[,] playerNames = 
    {
        { 
            "Cervantes", "Michael Jordan", "Yuna Kim", 
            "Chan Ho Park", "John Cena", "Michael Schumacher",
            "Peter Sagan", "Bob Ross", "and You"},
        {
            "Shandon Baptiste", "Richelor Sprangers", "Ethan Pinnock",
            "Ryan Trotman", "Wes Morgan", "Alphonso Davies",
            "Tomas Romero", "Mahlon Romeo", "and me"
        },
        {
            "À¯¼ö¿¬", "¹ÎÁØÈ«", "°íÁØ¿­",
            "ÁÖº¸¼º", "Àü¿ÏÀÍ", "ÇÑ½Â¹ü",
            "ÇÑ±¹ÄÜÅÙÃ÷ÁøÈï¿ø", "¼øÃµÇâ´ëÇÐ±³", "and us"
        }
    };

    private void ChangeLobby()
    {
        SceneChanger.instance.ChangeScene("Lobby");
        SoundManager.instance.PlayOneShotThere(Sound.Button);
    }

    private void Awake()
    {
        mainBtn.onClick.AddListener(() => ChangeLobby());
    }

    private void OnEnable()
    {
        int result = ResultData.resultCode;

        resultText.text = resultTexts[result];
        bestPlayerName.text = playerNames[result, UnityEngine.Random.Range(0, 9)];

        SoundManager.instance.PlayOneShotThere(result == 0 ? Sound.Win : Sound.Fail);
        SoundManager.instance.ChangeBounceVol(0.2f);
        if (result == 0) {
            EffectPooler.instance.SpawnEffect(Effect.Win, Vector2.zero, Vector3.zero);
        }

        if (result == 0)
        {
            bestPlayerImage.sprite = Resources.Load<Sprite>(@"Images\HomePlayer");
        }
        else
        {
            if (ResultData.lastHitAwayPlayer != null)
            {
                bestPlayerImage.sprite = Resources.Load<Sprite>(@"Images\AwayPlayerL" +
                    ResultData.lastHitAwayPlayer.level.ToString() + "Face");
                Debug.Log(ResultData.lastHitAwayPlayer.level);
            }
            else
            {
                bestPlayerImage.sprite = Resources.Load<Sprite>(@"Images\AwayPlayerL" +
                    UnityEngine.Random.Range(1,4) + "Face");
            }
        }
    }
}
