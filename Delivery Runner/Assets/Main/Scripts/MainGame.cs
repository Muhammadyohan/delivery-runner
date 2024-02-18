using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour
{
    public void GoToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
