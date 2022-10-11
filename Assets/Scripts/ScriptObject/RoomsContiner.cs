using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
[CreateAssetMenu(fileName = "RoomsContiner", menuName = "Diaco/RoomsContiner", order = 2)]
public class RoomsContiner : ScriptableObject
{
    public _RoomGroup Group;
    public string Name;

    public GameObject Prefab;
    public TextAsset JsonData;
    [PropertyOrder(0)]
    [Button("Add To List", ButtonSizes.Medium)]

    

    public void AddToContainer()
    {
        Rooms.Add(new Diaco.Manhatan.Structs.RoomContinerData {  group = this.Group.ToString(), name = this.Name, RoomPrefab = this.Prefab, roomData = this.JsonData});
    }
   
    [PropertyOrder(1)]
    [Searchable()]
    public List<Diaco.Manhatan.Structs.RoomContinerData> Rooms; 
}
