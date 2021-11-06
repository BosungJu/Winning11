using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoll : MonoBehaviour
{
    [SerializeField] Text m_text;
    [SerializeField] Image m_image;

    /// <summary>
    /// 주사위를 굴릴 시.
    /// </summary>
    public void OnButtonClick()
    {
        DiceGameData.RollDice();
    }
    /// <summary>
    /// 주사위 눈의 수에 따라 알맞는 이미지를 출력.
    /// </summary>
    void viewDIce()
    {
        // 주사위 눈에 따라 맞는 이미지 출력.
        switch (DiceGameData.redDice)
        {
            case 1:
                //m_image.sprite = ;
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
        }

        switch (DiceGameData.blueDice)
        {
            case 1:
                //m_image.sprite = ;
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
        }

        m_text.text = "Let's Start!";
    }
}
