using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void GoToScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void QuitApp()
    {
    #if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
    #else
         Application.Quit();
    #endif
    }
}
