using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DiceGameData
{
    public static int redDice;
    public static int blueDice;

    /// <summary>
    /// �ֻ����� ���� ���� ���� ����.
    /// </summary>
    public static void RollDice()
    {
        redDice = Random.Range(0, 6);
        blueDice = Random.Range(0, 6);

        DiceRoll.m_ViewBool = true;
    }
}
