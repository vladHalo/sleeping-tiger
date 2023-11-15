using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    [SerializeField] private Slider _progress;

    private void Start()
    {
        _progress.value = 0;
        StartCoroutine(RunLoad());
    }

    private IEnumerator RunLoad()
    {
        //yield return new WaitForSeconds(0.1f);
        // AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Str.Main, LoadSceneMode.Additive);
        // asyncLoad.allowSceneActivation = false;
        //
        // while (asyncLoad.progress < 0.9f)
        // {
        //     SetProgress(asyncLoad.progress);
        //     yield return null;
        // }
        //
        // yield return new WaitForSeconds(0.1f);
        //
        // SetProgress(0.9f);
        // asyncLoad.allowSceneActivation = true;
        // while (!asyncLoad.isDone) 
        // {
        //     yield return null;
        // }

        while (_progress.value != 1)
        {
            _progress.value += .01f;
            yield return new WaitForSeconds(.001f);
        }

        SceneManager.LoadScene(Str.Main);
    }

    //private void SetProgress(float value) => _progress.value = value;
}