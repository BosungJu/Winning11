using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DiceGameData
{
    public static int redDice;
    public static int blueDice;

    /// <summary>
    /// 주사위를 굴려 랜덤 값을 대입.
    /// </summary>
    public static void RollDice()
    {
        redDice = Random.Range(0, 6);
        blueDice = Random.Range(0, 6);

        DiceRoll.m_ViewBool = true;
    }
}
