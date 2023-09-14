using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Dominos : MonoBehaviour
{

    public float fadeTime;
    public CanvasGroup dominosGroup, ludoGroup, othersGroup;
    public RectTransform dominosRect, ludoRect, othersRect;
    

    public void DominosFadeIn()
    {
        dominosGroup.alpha = 0f;
        dominosRect.transform.localPosition = new Vector3(1000f, -62f, 0f);
        dominosRect.DOAnchorPos(new Vector2(0f, -62f), fadeTime, false).SetEase(Ease.Linear);
        dominosGroup.DOFade(1, fadeTime);
        ludoGroup.alpha = 0f;
        othersGroup.alpha = 0f;
    }
    
    public void LudoFadeIn()
    {
        ludoGroup.alpha = 0f;
        ludoRect.transform.localPosition = new Vector3(-1000f, -97f, 0f);
        ludoRect.DOAnchorPos(new Vector2(0f, -97f), fadeTime, false).SetEase(Ease.Linear);
        ludoGroup.DOFade(1, fadeTime);
        dominosGroup.alpha = 0f;
        othersGroup.alpha = 0f;
    }
    public void OthersFadeIn()
    {
        othersGroup.alpha = 0f;
        othersRect.transform.localPosition = new Vector3(1000f, -62f, 0f);
        othersRect.DOAnchorPos(new Vector2(0f, -62f), fadeTime, false).SetEase(Ease.Linear);
        othersGroup.DOFade(1, fadeTime);
        ludoGroup.alpha = 0f;
        dominosGroup.alpha = 0f;
    }
    
}
