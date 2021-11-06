using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : Singleton<SceneChanger>
{
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeScene(string name)
    {
        //SceneManager.LoadScene(name);
        StartCoroutine(LoadSceneRoutine(name));
    }

    private IEnumerator LoadSceneRoutine(string name) {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);
        while (!asyncLoad.isDone) {
            yield return null;
        }
        yield break;
    }
}
