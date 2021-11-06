using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Action startGameEvent;
    public Action endGameEvnent;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
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
