using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public GameObject LoadingScreen;
    public GameObject BoyModel;
    public GameObject GirlModel;

    public Image LoadingBarFill;
    public void PlayGame()
    {
        LoadingScreen.SetActive(true);
        StartCoroutine(LoadSceneAsync(1));
    }

    public void GirlSelected()
    {
        BoyModel.SetActive(false);
        GirlModel.SetActive(true);
        CharacterSelectionController.characterSelected = 1;
    }

    public void BoySelected()
    {
        GirlModel.SetActive(false);
        BoyModel.SetActive(true);
        CharacterSelectionController.characterSelected = 2;
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            LoadingBarFill.fillAmount = progressValue;

            yield return null;
        }
    }
}
