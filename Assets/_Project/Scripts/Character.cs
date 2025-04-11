using DG.Tweening;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Vector3 _startScale;

    public void Initialize()
    {
        _startScale = transform.localScale;
    }

    public void OnClick()
    {
        Shake();
    }

    private void Shake()
    {
        DOTween.Sequence()
                    .Append(transform.DOScale(_startScale.x * 0.8f, 0.1f))
                    .Append(transform.DOScale(_startScale.x, 0.1f));
    }
}
