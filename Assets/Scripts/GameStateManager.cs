using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private bool isPaused;

    [Header("UI Game State Screens")]
    //[SerializeField] private GameObject start;
    [SerializeField] private GameObject pause;
    //[SerializeField] private GameObject gameover;

    void Update()
    {
        //TODO implement Gameover

        if (!isPaused && Input.GetKeyDown("p"))
        {
            PauseGame();
        }

        else if (isPaused && Input.GetKeyDown("p"))
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        StopGame();
        Cursor.visible = true;
        pause.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        StartGame();
        Cursor.visible = false;
        pause.SetActive(false);
        isPaused = false;
    }

    public void StopGame()
    {
        Time.timeScale = 0;
    }
    public void StartGame()
    {
        Time.timeScale = 1;
    }
}
