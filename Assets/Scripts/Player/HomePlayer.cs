using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HomePlayer : MonoBehaviour, IPlayer // collider ´Â trigger·Î
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

    public void OnHitted(Rigidbody2D boll)
    {
        float scala = boll.velocity.sqrMagnitude;
        float left = GoalPost.instance.leftEndPoint;
        float right = GoalPost.instance.rightEndPoint;

        Vector2 direction = new Vector3(Random.Range(left, right), GoalPost.instance.transform.position.y, 0) - transform.position;
        boll.position = transform.position;
        boll.velocity = direction.normalized * scala;
    }
}
