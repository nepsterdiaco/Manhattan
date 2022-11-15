using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class FadeEffect : MonoBehaviour
{


    public CanvasGroup FadeOutFadeInGroup;

    private  bool IsFadeIn = false;

    private  bool IsFadeOut = false;
 
    public Tween FadeIn(float FadeInDuration)
    {
        FadeOutFadeInGroup.blocksRaycasts = true;
       var t =  FadeOutFadeInGroup.DOFade(1.0f, FadeInDuration).OnComplete(() =>
        {
            IsFadeIn = true;
            IsFadeOut = false;
        });
        return t;
    }
    public Tween FadeOut( float FadeOutDuration)
    {
       var t =  FadeOutFadeInGroup.DOFade(0.0f, FadeOutDuration).OnComplete(() =>
        {
            IsFadeIn = false;
            IsFadeOut = true;
            FadeOutFadeInGroup.blocksRaycasts = false;
        });
        return t;
    }
}
