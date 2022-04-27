using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// manages scene loading and application handling
/// </summary>
public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public int sceneToLoad;

    /// <summary>
    /// loads scene specified by local value
    /// </summary>
    public void SceneLoad()
    {
        SceneManager.LoadScene(sceneToLoad);  
    }

    /// <summary>
    /// quits application
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

}
