using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoll : MonoBehaviour
{
    [SerializeField] Text m_text;
    [SerializeField] Image m_image;

    /// <summary>
    /// �ֻ����� ���� ��.
    /// </summary>
    public void OnButtonClick()
    {
        DiceGameData.RollDice();
    }
    /// <summary>
    /// �ֻ��� ���� ���� ���� �˸´� �̹����� ���.
    /// </summary>
    void viewDIce()
    {
        // �ֻ��� ���� ���� �´� �̹��� ���.
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
