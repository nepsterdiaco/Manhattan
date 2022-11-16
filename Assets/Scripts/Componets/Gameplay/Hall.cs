using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diaco.Manhatan
{
    public class Hall : MonoBehaviour
    {
        public List<RoomPanelInHall> roomPanelInHall;


        
        public void Start()
        {
           
           
            ActiveRoom();
        }




        private void ActiveRoom()
        {

            for (int i = 0; i < roomPanelInHall.Count; i++)
            {
                roomPanelInHall[i].Number_text.text = (i + 1).ToString();

            }
            for (int i = 0; i < roomPanelInHall.Count; i++)
            {
                var numberroom = System.Convert.ToInt32(roomPanelInHall[i].Number_text.text);
                for (int j = 0; j < Manager.singleton.AppartementsSelectedInFloor.Count; j++)
                {
                    var unit = Manager.singleton.AppartementsSelectedInFloor[j].unit;
                    if (unit == numberroom)
                    {
                        roomPanelInHall[i].SetRoomActive(true);
                    //    Debug.Log("ON:" + unit);
                    }
                  /*  else
                    {
                        roomPanelInHall[i].SetRoomActive(false);
                    }*/
                }
              
            }

        }


    }

}