using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slinger : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Rigidbody2D m_Ball;
    public RectTransform startRange;
    public RectTransform slingerPoint;

    bool isDrag;
    float range = 600;

    private void OnDragging(Vector2 vec)
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDrag = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos = startRange.position;
        
        Vector2 direction = new Vector2(eventData.position.x - pos.x, eventData.position.y - pos.y);
        direction = Vector2.ClampMagnitude(direction, range / 2);
        slingerPoint.localPosition = direction;
        float distance = slingerPoint.localPosition.sqrMagnitude / Mathf.Pow(range, 2);

        Debug.Log(distance * 3000);
        startRange.sizeDelta = new Vector2(Mathf.Clamp(distance * 3000, 140, range + 140), Mathf.Clamp(distance * 3000, 140, range + 140));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;
        Vector3 vec = startRange.position - (Vector3)eventData.position;
        m_Ball.AddForce(vec.normalized * 300f);
        slingerPoint.position = startRange.position;
        startRange.sizeDelta = new Vector2(140, 140);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        
    }
}
