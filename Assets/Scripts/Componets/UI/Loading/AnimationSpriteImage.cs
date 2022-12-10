using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Diaco.Manhatan.UI
{
    public class AnimationSpriteImage : MonoBehaviour
    {
        public List<Sprite> SpriteData;
        public Image Renderer;
        public bool PlayAutomatic = false;
        public float DurationSequence;
        public bool RepeatAnimation;
        public int RepeateAnimationCount;


        public void OnEnable()
        {
            if (PlayAutomatic)
                StartCoroutine(PlaySprite());
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
    }
}
