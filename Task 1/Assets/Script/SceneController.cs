using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    public Component loader;
    private ILoader iloader;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        iloader = (ILoader)loader;
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        iloader.LoadStart();

        yield return null;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        asyncOperation.allowSceneActivation = false;

        float p = 0;

        while (p < 1)
        {
            iloader.SetProgress(p);
            p += 0.1f;

            yield return new WaitForSeconds(0.1f);
        }

        while (asyncOperation.progress < 0.89f)
            yield return null;

        asyncOperation.allowSceneActivation = true;
        iloader.LoadEnd();
    }
}
