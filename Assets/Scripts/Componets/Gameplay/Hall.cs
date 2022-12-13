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
                roomPanelInHall[i].SetNumber((i + 1).ToString());

            }
            for (int i = 0; i < roomPanelInHall.Count; i++)
            {
                var numberroom = roomPanelInHall[i].Getnumber();
                for (int j = 0; j < Manager.singleton.AppartementsSelectedInFloor.Count; j++)
                {
                    var unit = Manager.singleton.AppartementsSelectedInFloor[j].unit;
                    if (unit == numberroom)
                    {
                        roomPanelInHall[i].SetRoomActive(true);
                       Debug.Log("ON:" + unit);
                    }
                    
                   /* else
                    {
                        roomPanelInHall[i].SetRoomActive(false);
                        Debug.Log("OFF:" + unit);
                    }*/
                }
              
            }

        }


    }

}