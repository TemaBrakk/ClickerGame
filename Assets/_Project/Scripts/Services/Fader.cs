using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class Fader : MonoBehaviour
{
    [SerializeField] private Image _faderImage;

    private const string FADER_PATH = "Fader";

    private static Fader _instance;
    public static Fader Instance
    {
        get
        {
            if (_instance == null)
            {
                Fader prefab = Resources.Load<Fader>(FADER_PATH);
                _instance = Instantiate(prefab);
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    public void FadeIn(Action callback)
    {
        gameObject.SetActive(true);
        _faderImage.DOFade(1f, 1f)
            .OnComplete(() => callback?.Invoke());
    }

    public void FadeOut(Action callback)
    {
        _faderImage.DOFade(0f, 1f)
            .OnComplete(() => callback?.Invoke())
            .OnComplete(() => gameObject.SetActive(false));
    }
}
