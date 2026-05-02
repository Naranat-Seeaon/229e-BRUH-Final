using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [Header("ตั้งค่าการเก็บของ")]
    public int applesToWin = 7; // จำนวนแอปเปิลที่ต้องเก็บให้ครบเพื่อชนะ
    private int collectedApples = 0; // จำนวนที่เก็บได้ตอนนี้

    [Header("ลาก UI มาใส่ตรงนี้")]
    public TextMeshProUGUI scoreText; // ลากข้อความคะแนนมาใส่
    public GameObject victoryPanel;   // ลากหน้าต่าง You Win มาใส่

    void Start()
    {
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(false); 
        }
        UpdateScoreUI();
    }

    public void AddApple()
    {
        collectedApples++;
        UpdateScoreUI();

        if (collectedApples >= applesToWin)
        {
            WinGame();
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Apples: " + collectedApples + " / " + applesToWin;
        }
    }

    void WinGame()
    {
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
        }
        Time.timeScale = 0f;
    }


    public void ReturnToMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Menu"); 
    }
}