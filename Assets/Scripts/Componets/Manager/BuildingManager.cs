using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
namespace Diaco.Manhatan
{
    public class BuildingManager : MonoBehaviour
    {
        public static List<Building> buildings = new List<Building>();

        public static void  AddBuilding( Building building)
        {
            if(!buildings.Contains(building))
            {
                buildings.Add(building);
            }
        }
    }




}