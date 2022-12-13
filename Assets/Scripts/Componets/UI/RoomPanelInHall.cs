using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;
namespace Diaco.Manhatan
{
    public class RoomPanelInHall : MonoBehaviour
    {
        [SerializeField]private TextMeshProUGUI Number_text;
        [SerializeField]private GameObject Lock_status;
        [SerializeField]private GameObject unLock_status;

        private bool IsActiveForEnter = false;
        public void SetRoomActive(bool active)
        {

            //EnterRoom_button.onClick.RemoveAllListeners();
            
            if (active)
            {
                IsActiveForEnter = true;
                Number_text.color = Color.green;
                Lock_status.SetActive(false);
                unLock_status.SetActive(true);
               // Debug.Log("active");
            }
            else
            {
                IsActiveForEnter = false;
                Number_text.color = Color.red;
                Lock_status.SetActive(true);
                unLock_status.SetActive(false);
               // Debug.Log("deactive");
            }


        }
        public void SetNumber(string num)
        {
            Number_text.text = num;
        }
        public int Getnumber()
        {
            return System.Convert.ToUInt16(Number_text.text);
        }
        public void EnterRoom()
        {
            if(IsActiveForEnter)
            {
                //EnterRoom_button.interactable = false;
                Manager.singleton.NumberUnitSelected = System.Convert.ToInt32(Number_text.text);
                Manager.singleton.LoadScene(4);
            }
        }
    }
}