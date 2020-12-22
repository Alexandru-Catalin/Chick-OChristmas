using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject loadingScreen;

    public void PlayGame(int sceneIndex)
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        Time.timeScale = 1f;

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Time.timeScale = 1f;
            yield return null;
        }
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");

        Application.Quit();
    }

}
