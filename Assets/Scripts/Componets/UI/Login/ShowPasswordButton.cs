using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
namespace Diaco.Manhatan.UI
{
    public class ShowPasswordButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private Image ImageRenderer;
        [SerializeField] private Sprite EyeShow_Sprite;
        [SerializeField] private Image RayEye_image;
        [SerializeField] private Sprite EyeDontShow_Sprite;

        public void OnPointerEnter(PointerEventData eventData)
        {
            ShowPass(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ShowPass(false);
        }
        private void ShowPass(bool show)
        {
            if (show)
            {
                inputField.contentType = TMP_InputField.ContentType.Standard;
                RayEye_image.enabled = true;
                ImageRenderer.sprite = EyeShow_Sprite;
            }
            else
            {
                inputField.contentType = TMP_InputField.ContentType.Password;
                RayEye_image.enabled = false;
                ImageRenderer.sprite = EyeDontShow_Sprite;
            }
            inputField.ForceLabelUpdate();
        }
    }
}
