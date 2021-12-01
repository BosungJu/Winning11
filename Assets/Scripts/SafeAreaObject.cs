using UnityEngine;

[ExecuteInEditMode]
public class SafeAreaObject : MonoBehaviour
{
    private void Start()
    {
        Rect safeArea = Screen.safeArea;

        var rect = GetComponent<RectTransform>();
        if (!safeArea.Contains(rect.anchoredPosition - rect.sizeDelta / 2))
        {

        }
    }
}