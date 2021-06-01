using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

/// <summary>
/// Class governs the gamestates paused (game)
/// </summary>
public class GameStateManager : MonoBehaviour
{

    [Header("UI Game State Screens")]
    //[SerializeField] private GameObject start;
    //[SerializeField] private GameObject gameover;
    
    [SerializeField] private GameObject pause;

    [HideInInspector]
    public bool isPaused = false;
    
    private PlayerControls playerControls;
    private InputAction pauseMenu;

    bool gameHasEnded = false;


    private void Awake()
    {
        playerControls = new PlayerControls();
        pauseMenu = playerControls.Gameplay.InteractPauseMenu;
        pauseMenu.performed += OnPauseGame;
    }

    private void OnPauseGame(InputAction.CallbackContext context)
    {
        if (!isPaused)
        {
            PauseGame();
            isPaused = true;
        }
        else
        {
            UnPauseGame();
            isPaused = false;
        }
    }

    private void OnEnable() => playerControls.Enable();

    private void OnDisable() => playerControls.Disable();

    void Update()
    {

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        HealthBar.amountOfHealthToLoose = 0f;
        pause.SetActive(true);
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        HealthBar.amountOfHealthToLoose = 0.01f;
        pause.SetActive(false);
    }

    public void  EndGame()
    {
        //only call gameover once
        if(gameHasEnded == false)
        {
            SceneManager.LoadScene(2);
            gameHasEnded = true;
            ResetPlayerProperties();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    void ResetPlayerProperties()
    {
        PlayerProperties.amountFood = 0;
        PlayerProperties.amountWood = 0;
        PlayerProperties.amountStone = 0;
    }

}
