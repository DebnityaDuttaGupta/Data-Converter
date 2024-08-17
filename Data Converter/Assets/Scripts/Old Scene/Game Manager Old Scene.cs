using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerOldScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
