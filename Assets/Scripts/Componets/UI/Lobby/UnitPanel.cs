using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diaco.Manhatan.UI
{
    public class UnitPanel:BaseUIPanel
    {
        [SerializeField] private UnitData unitData;
        [SerializeField] private RectTransform Content;


        private void OnEnable()
        {
            SpwanUintDataItem();
        }

        private void SpwanUintDataItem()
        {
            var user_info = Manager.singleton.UserInformation;
            var currentSelectedBuilding = Manager.singleton.NameBuildingSelected;
            List<int> temp_floor = new List<int>();
            for (int i = 0; i < user_info.userBuildings.Count; i++)
            {
                if(user_info.userBuildings[i].buildingName == currentSelectedBuilding)
                {
                   var total_unit = user_info.userBuildings[i].appartements.Count;
                    for (int j = 0; j < total_unit; j++)
                    {
                        var floor = user_info.userBuildings[i].appartements[j].floor;
                        if (!temp_floor.Contains(floor))
                        {
                            var item = Instantiate(unitData, Content);
                            item.Set(floor);
                            temp_floor.Add(floor);
                        }
                    }
                    break;
                }
            }
        }
    }
}
