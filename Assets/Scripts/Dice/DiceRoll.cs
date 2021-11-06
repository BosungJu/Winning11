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
    public bool CupDownMoveBool = false;   // 내려갈 때
    bool CupUpMoveBool = false;     // 올라갈 때

    float delta = 17.0f; // 좌(우)로 이동가능한(x)최대값
    float speed = 8.0f; // 이동속도

    bool m_delayBool;
    float m_delay;
    private void Start()
    {
        m_text.text = "Tap to Roll Dice";
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
            m_delay += Time.deltaTime;

            if (m_delay > 0.3f)
            {
                m_delayBool = true;
                CupUpMove();
            }
        }
    }

    /// <summary>
    /// 주사위를 굴릴 시.
    /// </summary>
    public void OnButtonClick()
    {
        if (m_NextScene == true) {
            // 게임 시작 씬
            //SceneManager.LoadScene("bsTest");
            SoundManager.instance.PlayOneShotThere(Sound.Button);
            SceneChanger.instance.ChangeScene("InGame");
            return;
        }

        DiceGameData.RollDice();    // 주사위 숫자 정하기.

        if (CupDownMoveBool == false)
        {
            MoveCupDown();
        }
        else if(CupUpMoveBool == false && CupDownMoveBool == true)
        {
            MoveCupUp();
        }
    }

    private bool canPlaySound;

    private void MoveCupDown() {
        CupDownMoveBool = true;
        CupUpMoveBool = false;
        canPlaySound = true;
        SoundManager.instance.PlayOneShotThere(Sound.Button);
    }

    private void MoveCupUp() {
        CupDownMoveBool = false;
        CupUpMoveBool = true;
        //m_NextScene = true;
        SoundManager.instance.PlayOneShotThere(Sound.Button);
    }

    /// <summary>
    /// 컵 위로 움직이기
    /// </summary>
    void CupUpMove()
    {
        Debug.Log("들어오녀ㅑ");
        if (m_delayBool)
        {
            m_text.text = "";
            m_Cup.transform.position = Vector3.MoveTowards(m_Cup.transform.position, targetUpPosition.transform.position, 60f);

            viewDIce();
        }
    }

    /// <summary>
    /// 컵 아래로 움직이기
    /// </summary>
    void CupDownMove()
    {
        m_text.text = "";
        m_Cup.transform.position = Vector3.MoveTowards(m_Cup.transform.position, targetDownPosition.transform.position, 60f);
    }

    /// <summary>
    /// 주사위 눈의 수에 따라 알맞는 이미지를 출력.
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

        m_NextScene = true;
        m_delayBool = false;
    }

    void CupMove()
    {
        Vector3 v =m_Cup.transform.position;
        v.x += delta * Mathf.Sin(Time.time * speed);
        m_Cup.transform.position = v;
        if (canPlaySound) {
            SoundManager.instance.PlayOneShotThere(Sound.Dice);
            canPlaySound = false;
        }
    }
}
