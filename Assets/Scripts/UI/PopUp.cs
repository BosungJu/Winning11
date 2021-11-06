using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopUp : MonoBehaviour, IPointerClickHandler
{
    public GameObject logo;
    public GameObject particleObj;

    public void OnPointerClick(PointerEventData eventData)
    {
        logo.SetActive(true);
        particleObj.SetActive(true);
        gameObject.SetActive(false);
    }
}
