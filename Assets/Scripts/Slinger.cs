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
    private Camera cam;
    private float maxSize = 1.4f;
    private float startSizeOffset;

    void Start()
    {
        cam = Camera.main;
        startSizeOffset = slingerPoint.sizeDelta.x;
    }

    private float GetAngle(Vector2 direction)
    {
        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
    }

    private void OnDragging(Vector2 vec)
    {
        float size = 1080f / Screen.width;
        Debug.Log("width: " + Screen.width);

        Vector3 pos = startRange.position;

        Vector2 direction = vec - (Vector2)pos;
        direction = Vector2.ClampMagnitude(direction, range / 2);
        slingerPoint.localPosition = direction;
        float distance = slingerPoint.localPosition.sqrMagnitude / Mathf.Pow(range, 2);

        startRange.sizeDelta = new Vector2(Mathf.Clamp(distance * 3000, 140, range + 140), Mathf.Clamp(distance * 3000, 140, range + 140));

        // Arrow
        arrow.sizeDelta = new Vector2(100, distance * 1500);
        Vector2 startWorldPos = startRange.position;
        Vector2 direction = (Vector2)cam.ScreenToWorldPoint(vec) - startWorldPos;
        direction = Vector2.ClampMagnitude(direction, maxSize);
        slingerPoint.position = startWorldPos + direction;
        float distance = slingerPoint.anchoredPosition.magnitude;
        float rangeSize = distance * 2 + startSizeOffset;
        if (rangeSize < 0.8f)
            rangeSize = 0.8f;
        startRange.sizeDelta = new Vector2(rangeSize, rangeSize);
        float arrowSize = distance / 2.4f + 0.13f;
        if (arrowSize < 0.175f)
            arrowSize = 0.175f;
        arrow.localScale = new Vector2(1, arrowSize);
        arrow.eulerAngles = new Vector3(0, 0, GetAngle(direction));
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        SoundManager.instance.PlayAiming();
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnDragging(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 vec = startRange.position - cam.ScreenToWorldPoint(eventData.position);
        m_Ball.AddForce(vec.normalized * 300f);
        slingerPoint.position = startRange.position;
        startRange.sizeDelta = new Vector2(startSizeOffset, startSizeOffset);
        ballCollider.enabled = true;
        gameObject.SetActive(false);
        EffectPooler.instance.SpawnEffect(Effect.Kick, startRange.position, new Vector3(0, 0, GetAngle(vec)));
        SoundManager.instance.StopAiming();
        SoundManager.instance.PlayOneShotThere(Sound.Shoot);
    }
}
