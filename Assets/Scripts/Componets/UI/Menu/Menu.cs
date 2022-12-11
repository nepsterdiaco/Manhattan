using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Diaco.Manhatan.UI
{
    public class Menu : BaseUIPanel
    {
        [SerializeField] private Button Settings_Button;
        [SerializeField] private Button Buildings_Button;
        [SerializeField] private Button OpenSea_Button;
        [SerializeField] private Button Creadits_Button;

        [SerializeField] private List<BaseUIPanel> NextMenu;
        [SerializeField] private BaseUIPanel BackMenu;


        private void OnEnable()
        {
            Settings_Button.onClick.AddListener(() => {
                if (!NextMenu[0].gameObject.activeSelf)
                {
                    this.gameObject.SetActive(false);
                    NextMenu[0].gameObject.SetActive(true);
                }
            });
            Buildings_Button.onClick.AddListener(() => {
                if (!NextMenu[1].gameObject.activeSelf)
                {
                    this.gameObject.SetActive(false);
                    NextMenu[1].gameObject.SetActive(true);
                }
            });
            OpenSea_Button.onClick.AddListener(() => {
                if (!NextMenu[2].gameObject.activeSelf)
                {
                    this.gameObject.SetActive(false);
                    NextMenu[2].gameObject.SetActive(true);
                }
            }); 
            Creadits_Button.onClick.AddListener(() => {
                if (!NextMenu[3].gameObject.activeSelf)
                {
                    this.gameObject.SetActive(false);
                    NextMenu[3].gameObject.SetActive(true);
                }
            });
 
        }
        private void OnDisable()
        {
            Settings_Button.onClick.RemoveAllListeners();
            Buildings_Button.onClick.RemoveAllListeners();
            OpenSea_Button.onClick.RemoveAllListeners();
            Creadits_Button.onClick.RemoveAllListeners();
        }
        private void Update()
        {


            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Back();
            }

        }
        private void Back()
        {
            if (!BackMenu.gameObject.activeSelf)
            {
                this.gameObject.SetActive(false);
                BackMenu.gameObject.SetActive(true);
            }
        }
    }
}
