using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

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

    private void OnEnable()
    {
        playerControls.Enable();

        var buttons = pause.GetComponent<MenuButtonHandler>().textButtons;

        //foreach (var button in buttons)
        //{
        //    if (button == buttons[0])
        //    {
        //        button.GetComponent<Animator>().SetBool("OnStart", true);
        //        button.GetComponent<Animator>().SetBool("Pressed", true);
        //    }
        //    else
        //    {
        //        button.GetComponent<Animator>().SetBool("OnStart", false);
        //    }
        //}

    }

    private void OnDisable() => playerControls.Disable();

    void Update()
    {

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        pause.SetActive(true);
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pause.SetActive(false);
    }
}
