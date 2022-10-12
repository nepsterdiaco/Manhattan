using Sirenix.OdinInspector;
using Sirenix.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[CreateAssetMenu(fileName = "StuffContiner", menuName = "Diaco/StuffContiner", order = 1)]
public class StuffContiner : ScriptableObject
{
    
    public List<GameObject> Prefabs;

    [PropertyOrder(0)]
    [Button("ADD To List", ButtonSizes.Medium)]
    public void AddToContainer()
    {
        foreach (var prefab in Prefabs)
        {
            var stuffObject = prefab.GetComponent<StuffObject>();
            stuffs.Add(new Diaco.Manhatan.Structs.StuffContinerData { group = stuffObject.GetGroup(), name = stuffObject.GetName(), prefab = prefab });
        }

        Prefabs = new List<GameObject>();
    }

    [Searchable( )]
    [PropertyOrder(1)]
    public List<Diaco.Manhatan.Structs.StuffContinerData> stuffs;
    


}



