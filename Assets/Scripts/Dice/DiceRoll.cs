using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoll : MonoBehaviour
{
    [SerializeField] Text m_text;
    [SerializeField] Image m_Redimage;
    [SerializeField] Image m_Blueimage;
    [SerializeField] List<Sprite> m_ListSprite;

     public static bool m_ViewBool  = false;

    private void Start()
    {
        m_text.text = "Tap to Roll Dices";
        m_Redimage.sprite = m_ListSprite[0];
        m_Blueimage.sprite = m_ListSprite[0];
    }

    /// <summary>
    /// �ֻ����� ���� ��.
    /// </summary>
    public void OnButtonClick()
    {
        DiceGameData.RollDice();

        if(m_ViewBool == true)
        {
            viewDIce();
        }
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
                m_Redimage.sprite = m_ListSprite[0];
                break;
            case 2:
                m_Redimage.sprite = m_ListSprite[1];
                break;
            case 3:
                m_Redimage.sprite = m_ListSprite[0];
                break;
            case 4:
                m_Redimage.sprite = m_ListSprite[1];
                break;
            case 5:
                m_Redimage.sprite = m_ListSprite[0];
                break;
            case 6:
                m_Redimage.sprite = m_ListSprite[1];
                break;
        }

        switch (DiceGameData.blueDice)
        {
            case 1:
                m_Blueimage.sprite = m_ListSprite[1];
                break;
            case 2:
                m_Blueimage.sprite = m_ListSprite[0];
                break;
            case 3:
                m_Blueimage.sprite = m_ListSprite[1];
                break;
            case 4:
                m_Blueimage.sprite = m_ListSprite[0];
                break;
            case 5:
                m_Blueimage.sprite = m_ListSprite[1];
                break;
            case 6:
                m_Blueimage.sprite = m_ListSprite[0];
                break;
        }

        m_text.text = "Let's Start!";
    }
}
