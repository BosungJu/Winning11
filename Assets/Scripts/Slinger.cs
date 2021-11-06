using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slinger : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Rigidbody2D m_Ball;
    public RectTransform m_RectTransform;

    bool isDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDrag = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;
        Vector3 vec = m_RectTransform.position - (Vector3)eventData.position;

        Debug.Log(vec.normalized);

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
