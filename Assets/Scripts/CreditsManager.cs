using UnityEngine;

public class CreditManager : MonoBehaviour
{
    [Header("ลาก UI มาใส่ 2 ช่องนี้")]
    public GameObject creditsPanel;
    public RectTransform contentTransform;

    [Header("ความเร็วตอนเลื่อน")]
    public float scrollSpeed = 50f;
    private Vector3 startPosition;

    void Start()
    { 
        if (creditsPanel != null)
        {
            creditsPanel.SetActive(false);
        }


        if (contentTransform != null)
        {
            startPosition = contentTransform.localPosition;
        }
    }
    void Update()
    {
        if (creditsPanel != null && creditsPanel.activeSelf && contentTransform != null)
        {
            contentTransform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);
        }
    }

    public void OpenCredits()
    {
        if (creditsPanel != null)
        {
            creditsPanel.SetActive(true);

            if (contentTransform != null)
            {
                contentTransform.localPosition = startPosition;
            }
        }
    }
}