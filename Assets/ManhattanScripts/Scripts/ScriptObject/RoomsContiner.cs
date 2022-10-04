using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomsContiner", menuName = "Diaco/RoomsContiner", order = 2)]
public class RoomsContiner : ScriptableObject
{

    public List<Diaco.Manhatan.Structs.RoomContinerData> Rooms; 
}
