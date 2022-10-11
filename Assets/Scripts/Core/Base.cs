using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;



public enum _RoomGroup { Royal_0 = 0 , Royal_1 = 1, Royal_2 = 2 }
public enum _StuffGroup { TV_0 = 0, Sofa_0 = 2, Refrigerator_0 = 3 }
namespace Diaco.Manhatan.Structs
{
    
    [Serializable]
    public struct Stuff
    {
        public string group;
      //  public string category;
       // public string BuildingType;
        public string name;
       // public GameObject prefab;
        public List<Material> materials;
    }
    [Serializable]
    public struct StuffContinerData
    {
        
        public string group;
       
        public string name;
        
        public GameObject prefab;
        
        public List<Material> materials;
    }
    [Serializable]
    public struct StuffInRoom
    {


        public bool Lock;
        public string group;
      //  public string category;
       // public string BuildingType;
        public string name;
        public GameObject stuffGameObject;
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;
    }
    [Serializable]
    public struct RoomData
    {
        public string group;
       public string name;
      // public List<string> StuffIdUsedInRoom;
        public List<StuffInRoom> stuffs;
    }
    [Serializable]
    public struct RoomContinerData
    {
        public string group;
        public string name;
        public GameObject RoomPrefab;
        public TextAsset roomData;
    }
    public struct Login
    {
        
    }

}
