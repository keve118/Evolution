using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

/// <summary>
/// Class collecting all methods tied to menu button behavoir
///     -- Attach to Canvas
///     -- Implement UnityEvent on button
///     -- Drag and drop canvas in UnityEvent delegate handler in inspector
/// </summary>
public class MenuDelegateCollection : MonoBehaviour
{
    public delegate void MenuDelegateAction();
    public delegate void LoadScene(int number);
    public MenuDelegateAction menuDelegateVoidAction;
    public LoadScene sceneLoaderDelegate;

    public int milliSecondDelay;


    public void RunDemo()
    {
        sceneLoaderDelegate = LoadSceneNumber;
        ExecuteAfterTime(500, sceneLoaderDelegate, 1);
    }

    public void Options()
    {
        Debug.Log("Opens the options menu");
    }

    public void QuitGame() //Will after build quit the game
    {
        menuDelegateVoidAction = Application.Quit;
        ExecuteAfterTime(500, menuDelegateVoidAction);
    }

    public void LoadMainMenuScene()
    {
        sceneLoaderDelegate = LoadSceneNumber;
        ExecuteAfterTime(500, sceneLoaderDelegate, 0);
    }

    public void ResumeGame() //To leverage this funciton the pause screen gameobject must implement the pause script!
    {
        menuDelegateVoidAction = gameObject.GetComponent<PauseMenu>().UIManager.GetComponent<GameStateManager>().UnPauseGame;
        ExecuteAfterTime(500, menuDelegateVoidAction);
    }

    public void LoadSceneNumber(int number)
    {
        SceneManager.LoadScene(number);
    }

    //Delays void action to allow menu sound to play before execution
    async void ExecuteAfterTime(int milliSeconds, MenuDelegateAction e)
    {
        await Task.Delay(milliSeconds);

        e.Invoke();
    }

    //Delays scene loading to allow menu sound to play. If string not number, create a method overload
    async void ExecuteAfterTime(int milliSeconds, LoadScene e, int sceneNumber)
    {
        await Task.Delay(milliSeconds);

        e.Invoke(sceneNumber);
    }
}
