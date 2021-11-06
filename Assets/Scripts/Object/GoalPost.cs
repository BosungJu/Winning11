using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPost : Singleton<GoalPost>
{
    [HideInInspector]
    public float leftEndPoint;
    [HideInInspector]
    public float rightEndPoint;

    public GameObject leftPost;
    public GameObject rightPost;
    public GameObject centerPost;

    public void SetPost()
    {
        float width = centerPost.transform.localScale.x;
        float pos = n / 2 + (n % 2 == 0 ? 0.5f : 0);

        Instantiate(leftPost, transform).transform.localPosition = new Vector3(pos - width, 0, 0);
        leftEndPoint = pos - width;
        for (int i = 0; i < n; ++i)
        {
            Instantiate(centerPost, transform).transform.localPosition = new Vector3(pos, 0, 0);
            pos += width;
        }

        Instantiate(rightPost, transform).transform.localPosition = new Vector3(pos, 0, 0);
        rightEndPoint = pos;
    }
}
