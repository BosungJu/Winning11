using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public List<int> points;
    private int[,] difficultList = new int[6, 3] 
    { 
        { 6, 0, 0 }, { 4, 2, 0 }, { 3, 3, 0 },
        { 3, 2, 1 }, { 2, 3, 1 }, { 2, 2, 2 } 
    };

    private void SpawnAwayPlayer(int grade)
    {
        switch (grade) 
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }

    private void SpawnPlayer()
    {
        // TODO 주사위 데이터 받아서 아군, 적 생성
        int difficult = 0;

        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < difficultList[difficult, i]; ++j)
            {
                SpawnAwayPlayer(i);
            }
        }
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
