using System.Collections;
using DG.Tweening;
using UnityEngine;

public class UIElement : MonoBehaviour
{
    private bool _isHide = false;
    private Sequence _sequence;

    private void OnEnable()
    {
        var canvas = GetComponent<Canvas>();
        canvas.worldCamera ??= Camera.main;
        transform.rotation = Camera.main.transform.rotation;
    }

    [SerializeField] protected float dy;
    [SerializeField] protected float duration;
    [SerializeField] protected Ease ease;

    public bool IsHide => _isHide;
    [ContextMenu("UIElement/Show")]
    public virtual void Show()
    {
        if (_isHide)
            transform.DOScale(Vector3.one, duration).SetEase(ease).OnComplete(() => _isHide = false);
    }
    [ContextMenu("UIElement/Hide")]
    public virtual void Hide()
    {
        if (!_isHide)
            transform.DOScale(Vector3.zero, duration).SetEase(ease).OnComplete(() => _isHide = true);
    }
}
