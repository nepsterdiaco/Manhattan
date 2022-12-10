
using UnityEngine;

namespace Diaco.Manhatan.UI
{
    public class Loading : MonoBehaviour
    {
        private CanvasGroup canvasGroup;
        public void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();
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
