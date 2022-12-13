using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Diaco.Manhatan.UI
{
    public class Loading : MonoBehaviour
    {

        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private List<Sprite> SpriteData;
        [SerializeField] private Image Renderer;
        [SerializeField] private bool PlayAutomatic = false;
        [SerializeField] private float DurationSequence;
        [SerializeField] private bool RepeatAnimation;
        [SerializeField] private int RepeateAnimationCount;

        public int SheetCount { set; get; }
        public void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            SheetCount = SpriteData.Count;
        }
        public void OnEnable()
        {
            SheetCount = SpriteData.Count;
            if (PlayAutomatic)
                StartCoroutine(PlaySprite());
        }

        public void SetRadialPrograssbar(int next)
        {
            Renderer.sprite = SpriteData[next];

        }
        public IEnumerator PlaySprite()
        {

            if (RepeatAnimation)
            {
                var repeated = 0;
                do
                {
                    for (int i = 0; i < SpriteData.Count; i++)
                    {
                        Renderer.sprite = SpriteData[i];
                        yield return new WaitForSecondsRealtime(DurationSequence);
                    }
                    repeated++;
                } while (repeated <= RepeateAnimationCount);
                Renderer.sprite = SpriteData[0];
            }
            else
            {
                for (int i = 0; i < SpriteData.Count; i++)
                {
                    Renderer.sprite = SpriteData[i];
                    yield return new WaitForSecondsRealtime(DurationSequence);
                }
                Renderer.sprite = SpriteData[0];
            }
        }


        public void Show(bool show)
        {
            if (show)
                canvasGroup.alpha = 1;
            else
                canvasGroup.alpha = 0;
        }
    }
}
