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

        else if (isPaused && Input.GetKeyDown("p") || Input.GetKeyDown("escape"))
        {
            UnPauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        pause.SetActive(true);
        isPaused = true;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
        pause.SetActive(false);
    }
}
