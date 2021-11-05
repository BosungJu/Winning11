using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Transform spawnPoints;
    private List<int> points = new List<int>();
    public Transform awayParent;
    private int[,] difficultList = new int[6, 3] 
    { 
        { 6, 0, 0 }, { 4, 2, 0 }, { 3, 3, 0 },
        { 3, 2, 1 }, { 2, 3, 1 }, { 2, 2, 2 } 
    };

    private void SpawnAwayPlayer(int grade)
    {
        int index = Random.Range(0, points.Count);
        Vector3 pos = spawnPoints.GetChild(points[index]).position;
        
        points.RemoveAt(index);

        switch (grade) // instantiate set parent >> awayParent
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
        points.Clear();
        for (int i = 0; i < spawnPoints.childCount; ++i)
        {
            points.Add(i);
        }

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
