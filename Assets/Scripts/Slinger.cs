using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slinger : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public CircleCollider2D ballCollider;
    public Rigidbody2D m_Ball;
    public RectTransform startRange;
    public RectTransform slingerPoint;

    public RectTransform arrow;

    bool isDrag;
    float range = 600;

    private float GetAngle(Vector2 direction)
    {
        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
    }

    private void OnDragging(Vector2 vec)
    {
        float size = 1080 / Screen.width;
        Debug.Log("width: " + Screen.width);

        Vector3 pos = startRange.position;

        Vector2 direction = vec - (Vector2)pos;
        direction = Vector2.ClampMagnitude(direction, range / 2 / size);
        slingerPoint.localPosition = direction * size;
        float distance = slingerPoint.localPosition.sqrMagnitude / Mathf.Pow(range / size, 2);

        startRange.sizeDelta = new Vector2(Mathf.Clamp(distance * 3000, 140, range + 140), Mathf.Clamp(distance * 3000, 140, range + 140));

        // Arrow
        arrow.sizeDelta = new Vector2(100, distance * 1500 / (size * 2));
        arrow.eulerAngles = new Vector3(0, 0, GetAngle(direction));
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDrag = true;
        SoundManager.instance.PlayAiming();
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnDragging(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;
        Vector3 vec = startRange.position - (Vector3)eventData.position;
        m_Ball.AddForce(vec.normalized * 300f);
        slingerPoint.position = startRange.position;
        startRange.sizeDelta = new Vector2(140, 140);
        ballCollider.enabled = true;
        arrow.gameObject.SetActive(false);
        float rotZ = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg - 90f;
        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector2 screenToWorldPosition = Camera.main.ScreenToWorldPoint(rectTransform.transform.position);
        EffectPooler.instance.SpawnEffect(Effect.Kick, screenToWorldPosition, new Vector3(0, 0, rotZ));
        SoundManager.instance.StopAiming();
        SoundManager.instance.PlayOneShotThere(Sound.Shoot);
    }
}
