using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    #region Play
    /// <summary>
    /// Changes Scene
    /// </summary>
    /// <param name="index">The scene it changes to</param>
    public void SceneChange(int index)
    {
        SceneManager.LoadScene(index);
    }
    #endregion
    #region Exit
    //Exits to desktop in build, stops playing in editor.
    public void ExitToDesktop()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }
    #endregion
}
