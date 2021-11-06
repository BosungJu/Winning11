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
    private float maxSize = 1.1f;
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
        Vector2 startWorldPos = startRange.position;
        Vector2 endWorldPos = cam.ScreenToWorldPoint(vec);
        Vector2 direction = endWorldPos - startWorldPos;
        direction = Vector2.ClampMagnitude(direction, maxSize);
        slingerPoint.position = startWorldPos + direction;
        float distance = slingerPoint.anchoredPosition.magnitude;
        float rangeSize = distance * 2 + startSizeOffset;
        if (rangeSize < 0.8f)
        {
            rangeSize = 0.8f;
        }
        startRange.sizeDelta = new Vector2(rangeSize, rangeSize);
        float arrowSize = distance / 2.5f + 0.14f;
        if (arrowSize < 0.175f)
        {
            arrowSize = 0.175f;
        }
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
        Vector2 screenToWorldPosition = startRange.position;
        EffectPooler.instance.SpawnEffect(Effect.Kick, screenToWorldPosition, new Vector3(0, 0, GetAngle(vec)));
        SoundManager.instance.StopAiming();
        SoundManager.instance.PlayOneShotThere(Sound.Shoot);
    }
}
