using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnOffButton : MonoBehaviour, IPointerClickHandler
{
    public bool isOn = true;

    public Image on;
    public Image off;

    public Action<bool> OnClickEvent;

    public void SetButtonImage() 
    {
        on.color = new Color(1, 1, 1, isOn ? 1 : 0);
        off.color = new Color(1, 1, 1, isOn ? 0 : 1);
    }

    public void OnClick()
    {
        isOn = !isOn;
        SetButtonImage();
        OnClickEvent(isOn);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick();
    }
}
