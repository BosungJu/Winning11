using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Action startGameEvent;
    public Action endGameEvnent;

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        // TODO ���� ���� �� �Ʊ� ���� ��ġ ����.
        startGameEvent();
    }

    private void FixedUpdate()
    {
        
    }
}
