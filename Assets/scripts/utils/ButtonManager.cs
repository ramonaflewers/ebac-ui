using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonManager : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerClickHandler
{
    [Header("Scale Animation")]
    public float scaleAmount = 1.2f;
    public float animationTime = 0.15f;

    [Header("Click Effect")]
    public ParticleSystem particlePrefab;

    private Vector3 originalScale;
    private Tween scaleTween;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ScaleTo(originalScale * scaleAmount);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ScaleTo(originalScale);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (particlePrefab == null) return;

        ParticleSystem ps = Instantiate(particlePrefab, transform);
        ps.transform.localPosition = Vector3.zero;
        ps.transform.localRotation = Quaternion.identity;

        ps.Play();

        Destroy(ps.gameObject, ps.main.duration + ps.main.startLifetime.constantMax);
    }

    private void ScaleTo(Vector3 target)
    {
        scaleTween?.Kill();
        scaleTween = transform.DOScale(target, animationTime);
    }
}
