using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Diaco.Manhatan
{
    [Obsolete]
    public class BuildingInfo_UI : MonoBehaviour
    {
        public TextMeshProUGUI BuildingName;
        public TextMeshProUGUI BuildingInfo;

        public Button Lobby_button;
       
      
        public void OnEnable()
        {
            
            Lobby_button.onClick.AddListener(() =>
            {

               // Manager.singleton.WorldMapCameraMoveEffect();

            });
        }
        public void OnDisable()
        {
            Lobby_button.onClick.RemoveAllListeners();
        }
        public void SetElement(string buildingname, string buildingInfo)
        {
            BuildingName.text = buildingname;
            BuildingInfo.text = buildingInfo;
        }

    }
}