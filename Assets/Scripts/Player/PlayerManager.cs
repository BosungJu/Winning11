using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private void SpawnPlayer()
    {
        // TODO 주사위 데이터 받아서 아군, 적 생성
    }

    private void Awake()
    {
        GameManager.instance.startGameEvent += SpawnPlayer;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
