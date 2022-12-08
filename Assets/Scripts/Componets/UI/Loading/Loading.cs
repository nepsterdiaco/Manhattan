using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Diaco.Manhatan.UI.Loading
{
    public class Loading : MonoBehaviour
    {
       [SerializeField] private CanvasGroup canvasGroup;
        public void Show(bool show)
        {
            if (show)
                canvasGroup.alpha = 1;
            else
                canvasGroup.alpha = 0;
        }
    }
}
