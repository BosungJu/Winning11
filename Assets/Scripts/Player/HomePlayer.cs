using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HomePlayer : MonoBehaviour, IPlayer
{
    private bool isDrag;

    private void OnDragging(Vector3 pos)
    {
        if (isDrag)
        {
            pos.z = 10;
            transform.position = Camera.main.ScreenToWorldPoint(pos);
        }
    }

    private void OnMouseDown()
    {
        isDrag = true;
        OnDragging(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        OnDragging(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        OnDragging(Input.mousePosition);
        isDrag = false;
    }

    public void OnHitted(Rigidbody2D ball)
    {
        // TODO 공을 상대 골대 쪽으로 쏘기 sqrMag.. 만큼의 힘으로 add force
        float scala = ball.velocity.sqrMagnitude;
        Vector2 direction = GoalPost.instance.transform.position - transform.position;
        ball.velocity = direction.normalized * scala;
        
    }
}
