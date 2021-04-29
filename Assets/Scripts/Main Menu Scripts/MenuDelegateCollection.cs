using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class collecting all methods tied to menu button behavoir
///     -- Attach to Canvas
///     -- Implement UnityEvent on button
///     -- Drag and drop canvas in UnityEvent delegate handler in inspector
/// </summary>
public class MenuDelegateCollection : MonoBehaviour
{
    public void RunDemo()
    {
        Debug.Log("Start function works and goes here");
    }

    public void Options()
    {
        Debug.Log("Opens the options menu");
    }

    public void QuitGame() //Will after build quit the game
    {
        Application.Quit();
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void ResumeGame() //To leverage this funciton the pause screen gameobject must implement the pause script!
    {
        gameObject.GetComponent<PauseMenu>().UIManager.GetComponent<GameStateManager>().StartGame();
    }
}
