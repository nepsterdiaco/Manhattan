using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

namespace Diaco.Manhatan.UI.Tab
{


    public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {

        [SerializeField] GameObject OptionsPanel;
        [SerializeField] [ColorUsage(true)] private Color HightlightedColor;
        [SerializeField] [ColorUsage(true)] private Color DeSelectedColor;
        
        [SerializeField] private bool IsClicked = false;
        
        [SerializeField] private TextMeshProUGUI Context; 
        [SerializeField] private Image HightlightBackground;
        
        private void OnEnable()
        {
            Context = GetComponentInChildren<TextMeshProUGUI>();
            
           /// HightlightBackground = GetComponentInChildren<Image>();
        }
        

        public void OnPointerEnter(PointerEventData eventData)
        {
            ActiveStatusTab(true);
            
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            TabController.instance.CloseAllTab();
            OpenOptionsTab(true);
            TabController.instance.HoldActiveThisTab(this);
            
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!IsClicked)
                ActiveStatusTab(false);
        }




        public void ActiveStatusTab(bool active)
        {
            if (active)
            {
                Context.color = HightlightedColor;
                HightlightBackground.enabled = active;
            }
            else
            {
                Context.color = DeSelectedColor;
                HightlightBackground.enabled = active;
                IsClicked = false;
            }

        }
        public void OpenOptionsTab(bool open)
        {
            IsClicked = open;
            OptionsPanel.SetActive(open);
           // Debug.Log("OPEN TAB : " + OptionsPanel.name);
            
        }
    }
}