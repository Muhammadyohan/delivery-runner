using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
<<<<<<< HEAD
using UnityEngine.UI;

=======
>>>>>>> a245512677b41ba41afd4570982510acdb6970b0
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
<<<<<<< HEAD
        SceneManager.LoadSceneAsync(1);
    }

=======
        SceneManager.LoadScene("CharacterSelectionScene");

    }
>>>>>>> a245512677b41ba41afd4570982510acdb6970b0
    public void QuitGame()
    {
        Application.Quit();
    }
}
