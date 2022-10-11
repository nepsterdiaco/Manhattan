using Sirenix.OdinInspector;
using Sirenix.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[CreateAssetMenu(fileName = "StuffContiner", menuName = "Diaco/StuffContiner", order = 1)]
public class StuffContiner : ScriptableObject
{
    public _StuffGroup Group;
    public string Name;
    
    public GameObject Prefab;

    [PropertyOrder(0)]
    [Button("ADD To List", ButtonSizes.Medium)]
    public void AddToContainer()
    {
        stuffs.Add(new Diaco.Manhatan.Structs.StuffContinerData { group = Group.ToString(), name = this.Name, prefab = this.Prefab });
    }

    [Searchable( )]
    [PropertyOrder(1)]
    public List<Diaco.Manhatan.Structs.StuffContinerData> stuffs;
    


}



