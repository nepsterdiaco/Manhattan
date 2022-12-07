using System;
using System.Collections;
using System.Collections.Generic;


using UnityEngine;

using TMPro;
using UnityEngine.EventSystems;

namespace Diaco.misc
{


    public class ActionButtonInEnterMouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {

        private TextMeshProUGUI context_text;

        void Start()
        {
            context_text = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            context_text = GetComponentInChildren<TextMeshProUGUI>();
        }


        public void OnPointerEnter(PointerEventData eventData)
        {

            context_text.color = new Color(1, 1, 1, 1);
            // Debug.Log("HELLO");

        }

        public void OnPointerExit(PointerEventData eventData)
        {
            context_text.color = new Color(1, 1, 1, 0.5f);
        }
    }
}