using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public int totalObjectives;
    private int currentScore = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // Automatically count how many items are in the map at the start
        totalObjectives = GameObject.FindGameObjectsWithTag("Item").Length;
        Debug.Log("Total items to collect: " + totalObjectives);
    }

    public void AddScore()
    {
        currentScore++;
        Debug.Log("Score: " + currentScore + " / " + totalObjectives);

        if (currentScore >= totalObjectives)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("Mission Complete! All objectives collected.");
        // You can restart the level or show a 'Win' screen here
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}