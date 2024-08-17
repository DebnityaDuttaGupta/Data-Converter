using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void SwitchToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadNextScene(string sceneName)
    {
        int newSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(newSceneIndex);
    }
}
