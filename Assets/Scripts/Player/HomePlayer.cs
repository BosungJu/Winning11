using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CircleCollider2D))]
public class HomePlayer : MonoBehaviour, IPlayer // collider ´Â trigger·Î
{
    private bool isDrag;
    private string pName;
    private Vector2 clickOffset;
    private Camera cam;

    void Awake() {
        cam = Camera.main;
    }

    private void OnDragging()
    {
        if (isDrag)
        {
            transform.position = GetMouseWorldPos() + clickOffset;
        }
    }

    private void OnMouseDown()
    {
        isDrag = true;
        clickOffset = (Vector2)transform.position - GetMouseWorldPos();
        OnDragging();
    }

    private void OnMouseDrag()
    {
        OnDragging();
    }

    private void OnMouseUp()
    {
        OnDragging();
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
        CameraShake.instance.Shake(direction.normalized);

        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        EffectPooler.instance.SpawnEffect(Effect.Kick, transform.position, new Vector3(0, 0, rotZ));
        SoundManager.instance.PlayOneShotThere(Sound.Player);
    }

    private Vector2 GetMouseWorldPos() {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        return cam.ScreenToWorldPoint(mousePos);
    }

    public string GetName()
    {
        return pName;
    }
}
