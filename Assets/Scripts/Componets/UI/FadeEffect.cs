using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Diaco.Manhatan.UI
{
    public class FadeEffect : MonoBehaviour
    {
        [SerializeField] private CanvasGroup FadeOutFadeInGroup;
        [SerializeField] private float Duration = 1.0f;
        private bool IsFadeIn = false;
        private bool IsFadeOut = false;
        public Tween FadeIn()
        {
            FadeOutFadeInGroup.blocksRaycasts = true;
            var t = FadeOutFadeInGroup.DOFade(1.0f, Duration).OnComplete(() =>
            {
                IsFadeIn = true;
                IsFadeOut = false;
            });
            return t;
        }
        public Tween FadeOut()
        {
            var t = FadeOutFadeInGroup.DOFade(0.0f, Duration).OnComplete(() =>
            {
                IsFadeIn = false;
                IsFadeOut = true;
                FadeOutFadeInGroup.blocksRaycasts = false;
            });
            return t;
        }
    }
}