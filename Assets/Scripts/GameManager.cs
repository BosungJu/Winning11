using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Action startGameEvent;

    private void Awake()
    {

    }


    public void StartGame()
    {
        // TODO ���� ���� �� �Ʊ� ���� ��ġ ����.
        startGameEvent();
    }

    
}
