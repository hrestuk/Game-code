using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentSceneId = 0;
    int sceneAmount = 0;
    private void Awake() 
    {
        currentSceneId = SceneManager.GetActiveScene().buildIndex;
        sceneAmount = SceneManager.sceneCountInBuildSettings;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(currentSceneId);
    }
    public void NextLevel()
    {
        if (sceneAmount > currentSceneId+1)
        {
            SceneManager.LoadScene(currentSceneId+1);
        }
        
    }
}
