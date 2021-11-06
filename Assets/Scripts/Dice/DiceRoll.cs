using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DiceRoll : MonoBehaviour
{
    [SerializeField] Text m_text;
    [SerializeField] Image m_Redimage;
    [SerializeField] Image m_Blueimage;
    [SerializeField] GameObject m_Cup;
    [SerializeField] List<Sprite> m_ListSprite;
    [SerializeField] GameObject targetUpPosition;
    [SerializeField] GameObject targetDownPosition;

    bool m_ViewBool  = false;
    bool m_NextScene = false;
    public bool CupDownMoveBool = false;   // ������ ��
    bool CupUpMoveBool = false;     // �ö� ��

    float delta = 17.0f; // ��(��)�� �̵�������(x)�ִ밪
    float speed = 8.0f; // �̵��ӵ�

    private void Start()
    {
        m_text.text = "Tap to Roll Dices";
        m_Redimage.sprite = m_ListSprite[0];
        m_Blueimage.sprite = m_ListSprite[6];
    }

    private void Update()
    {
        if (CupDownMoveBool == true)
        {
            CupDownMove();

            if (Mathf.Approximately(m_Cup.transform.localPosition.y, 0))
            {
                CupMove();
            }
        }
        else if (CupUpMoveBool == true)
        {
            CupUpMove();
        }
    }

    /// <summary>
    /// �ֻ����� ���� ��.
    /// </summary>
    public void OnButtonClick()
    {
        if (m_NextScene == true) {
            // ���� ���� ��
            //SceneManager.LoadScene("bsTest");
            SceneChanger.instance.ChangeScene("InGame");
            return;
        }

        DiceGameData.RollDice();    // �ֻ��� ���� ���ϱ�.

        if (CupDownMoveBool == false)
        {
            CupDownMoveBool = true;
            CupUpMoveBool = false;
        }
        else if(CupUpMoveBool == false && CupDownMoveBool == true)
        {
            CupDownMoveBool = false;
            CupUpMoveBool = true;

            m_NextScene = true;
        }
    }

    /// <summary>
    /// �� ���� �����̱�
    /// </summary>
    void CupUpMove()
    {
        m_text.text = "";
        m_Cup.transform.position = Vector3.MoveTowards(m_Cup.transform.position, targetUpPosition.transform.position, 20f);

        viewDIce();
    }

    /// <summary>
    /// �� �Ʒ��� �����̱�
    /// </summary>
    void CupDownMove()
    {
        m_text.text = "";
        m_Cup.transform.position = Vector3.MoveTowards(m_Cup.transform.position, targetDownPosition.transform.position, 20f);
    }

    /// <summary>
    /// �ֻ��� ���� ���� ���� �˸´� �̹����� ���.
    /// </summary>
    void viewDIce()
    {
        switch (DiceGameData.redDice)
        {
            case 0:
                m_Redimage.sprite = m_ListSprite[0];
                break;
            case 1:
                m_Redimage.sprite = m_ListSprite[1];
                break;
            case 2:
                m_Redimage.sprite = m_ListSprite[2];
                break;
            case 3:
                m_Redimage.sprite = m_ListSprite[3];
                break;
            case 4:
                m_Redimage.sprite = m_ListSprite[4];
                break;
            case 5:
                m_Redimage.sprite = m_ListSprite[5];
                break;
        }

        switch (DiceGameData.blueDice)
        {
            case 0:
                m_Blueimage.sprite = m_ListSprite[6];
                break;
            case 1:
                m_Blueimage.sprite = m_ListSprite[7];
                break;
            case 2:
                m_Blueimage.sprite = m_ListSprite[8];
                break;
            case 3:
                m_Blueimage.sprite = m_ListSprite[9];
                break;
            case 4:
                m_Blueimage.sprite = m_ListSprite[10];
                break;
            case 5:
                m_Blueimage.sprite = m_ListSprite[11];
                break;
        }
        m_text.text = "Let's Start!";
    }

    void CupMove()
    {
        Vector3 v =m_Cup.transform.position;
        v.x += delta * Mathf.Sin(Time.time * speed);
        m_Cup.transform.position = v;
    }
}
