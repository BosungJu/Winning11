using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{ 
    private List<int> points = new List<int>();
    private int[,] difficultList = new int[6, 3] 
    { 
        { 6, 0, 0 }, { 4, 2, 0 }, { 3, 3, 0 },
        { 3, 2, 1 }, { 2, 3, 1 }, { 2, 2, 2 } 
    };

    public Transform spawnPoints;
    public Transform awayParent;
    public List<GameObject> awayObjs; // 인스펙터에서 넣어주기.

    private void SpawnAwayPlayer(int grade)
    {
        int index = Random.Range(0, points.Count);
        Vector3 pos = spawnPoints.GetChild(points[index]).position;
        
        points.RemoveAt(index);

        Instantiate(awayObjs[grade], awayParent).transform.position = pos;
    }

    private void SpawnPlayer()
    {
        points.Clear();
        for (int i = 0; i < spawnPoints.childCount; ++i)
        {
            points.Add(i);
        }

        int difficult = DiceGameData.redDice;

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
        DontDestroyOnLoad(gameObject);
        GameManager.instance.startGameEvent += SpawnPlayer;
    }
}
