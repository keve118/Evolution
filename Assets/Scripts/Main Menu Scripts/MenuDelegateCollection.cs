using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.Collections;

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
    public LoadScene sceneLoaderDelegate;


    [SerializeField] private GameObject loadingScreen;
    public Slider slider;
    
    [SerializeField] private int milliSecondDelay = 500;
    
    private MenuDelegateAction menuDelegateVoidAction;

    public void RunDemo()
    {
        sceneLoaderDelegate = LoadSceneNumber;
        ExecuteAfterTime(milliSecondDelay, sceneLoaderDelegate, 1);
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
        ExecuteAfterTime(milliSecondDelay, menuDelegateVoidAction);
    }

    public void LoadSceneNumber(int number)
    {
        StartCoroutine(LoadAsync(number));
    }

    IEnumerator LoadAsync (int sceneNumber)
    {
        var asyncOperation = SceneManager.LoadSceneAsync(sceneNumber);

        while (!asyncOperation.isDone)
        {
            loadingScreen.SetActive(true);
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            slider.value = progress;
            yield return null;
        }
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
