using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slinger : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Rigidbody2D m_Ball;
    public RectTransform m_RectTransform;
    public GameObject slingerPoint;
    public GameObject startRange;

    bool isDrag;
    float width;

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDrag = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Vector3 vec = m_RectTransform.position - (Vector3)eventData.position;
        Vector3 vec = eventData.position;

        width = Vector3.Distance(eventData.position, startRange.transform.position);

        Debug.Log(width);
        slingerPoint.transform.position = vec;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;
        Vector3 vec = m_RectTransform.position - (Vector3)eventData.position;
        m_Ball.AddForce(vec.normalized * 300f);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        
    }
}
