using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Action startGameEvent;
    public CameraShake cameraShake;

    private void Awake()
    {

    }


    public void StartGame()
    {
        // TODO ���� ���� �� �Ʊ� ���� ��ġ ����.
        startGameEvent();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cameraShake.Shake(Vector2.left);
        }
    }
}
