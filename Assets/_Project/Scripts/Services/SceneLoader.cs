using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private const string GAME_SCENE_NAME = "GameScene";
    private const string MAIN_MENU_SCENE_NAME = "MainMenuScene";

    private bool _isLoading;

    private static SceneLoader _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(_instance.gameObject);
    }

    public void LoadGameScene()
    {
        if (_isLoading)
            return;

        StartCoroutine(LoadSceneRoutine(GAME_SCENE_NAME));
    }

    public void LoadMainMenuScene()
    {
        if (_isLoading)
            return;

        StartCoroutine(LoadSceneRoutine(MAIN_MENU_SCENE_NAME));
    }

    private IEnumerator LoadSceneRoutine(string sceneName)
    {
        _isLoading = true;

        bool isFading = true;
        Fader.Instance.FadeIn(() => isFading = false);
        
        while (isFading)
            yield return null;

        AsyncOperation loading = SceneManager.LoadSceneAsync(sceneName);
        loading.allowSceneActivation = false;

        while (loading.progress < 0.9f)
            yield return null;

        loading.allowSceneActivation = true;

        isFading = true;
        Fader.Instance.FadeOut(() => isFading = false);

        while (isFading)
            yield return null;

        _isLoading = false;
    }
}
