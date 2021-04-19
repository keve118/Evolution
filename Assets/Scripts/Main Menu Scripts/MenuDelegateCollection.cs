using UnityEngine;

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

    //Will after build quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
