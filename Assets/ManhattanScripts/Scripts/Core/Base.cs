using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diaco.Manhatan.Structs
{
    public enum StuffTag { A,B,C,D,F,G,H}
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
