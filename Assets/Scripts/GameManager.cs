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
        // TODO 시작 설정 및 아군 선수 배치 시작.
        startGameEvent();
    }

    
}
