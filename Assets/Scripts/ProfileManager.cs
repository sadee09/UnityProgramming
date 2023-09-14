
using UnityEngine;
using DG.Tweening;

public class ProfileManager : MonoBehaviour
{
    public float fadeTime;
    public CanvasGroup canvasGroup;
    public RectTransform rectTransform;
    

    public void PanelFadeIn()
    {
        canvasGroup.alpha = 0f;
        rectTransform.transform.localPosition = new Vector3(0f, -1500f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1, fadeTime);
    }

    public void PanelFadeOut()
    {
        canvasGroup.alpha = 1f;
        rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, -1500f), fadeTime, false).SetEase(Ease.Flash);
        canvasGroup.DOFade(0, fadeTime);
    }
    
}

