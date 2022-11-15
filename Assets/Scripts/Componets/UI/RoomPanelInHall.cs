using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;
namespace Diaco.Manhatan
{
    public class RoomPanelInHall : MonoBehaviour
    {
        public TextMeshProUGUI Number_text;
        public Button EnterRoom_button;

        
        private bool IsActiveForEnter = false;
        public void SetRoomActive(bool active)
        {
            
            EnterRoom_button.onClick.RemoveAllListeners();
            if (active)
            {
                IsActiveForEnter = true;
                Number_text.color = Color.green;
                EnterRoom_button.interactable = true;
                EnterRoom_button.onClick.AddListener(() => {

                    Manager.singleton.NumberUnitSelected = System.Convert.ToInt32(Number_text.text);
                    
                    EnterRoom_button.interactable = false;
                });
            }
            else
            {
                IsActiveForEnter = false;
                Number_text.color = Color.red;
                
                EnterRoom_button.interactable = false;
            }


        }
        public void EnterRoom()
        {
            if(IsActiveForEnter)
            {
                EnterRoom_button.interactable = false;
                Manager.singleton.NumberUnitSelected = System.Convert.ToInt32(Number_text.text);
            }
        }
    }
}