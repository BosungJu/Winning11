using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CircleCollider2D))]
public class HomePlayer : MonoBehaviour, IPlayer // collider ´Â trigger·Î
{
    private bool isDrag;
    private string pName;
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
        float scala = Mathf.Sqrt(ball.velocity.sqrMagnitude);
        float left = GoalPost.instance.leftEndPoint;
        float right = GoalPost.instance.rightEndPoint;

        Vector2 direction = new Vector3(Random.Range(left, right), GoalPost.instance.transform.position.y, 0) - transform.position;
        ball.position = transform.position;
        ball.velocity = direction.normalized * scala;
    }

    public string GetName()
    {
        return pName;
    }
}
