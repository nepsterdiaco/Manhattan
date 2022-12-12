using Sirenix.OdinInspector;
using Sirenix.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using Diaco.Manhatan.Structs;
using UnityEngine;

[CreateAssetMenu(fileName = "StuffContiner", menuName = "Diaco/StuffContiner", order = 1)]
public class StuffContiner : ScriptableObject
{
    private List<GameObject> Prefabs;

    [PropertyOrder(0)]
    [Button("ADD To List", ButtonSizes.Medium)]
    public void AddToContainer()
    {
        stuffs = new List<StuffContinerData>();
        AddToStuffs();
        foreach (var prefab in Prefabs)
        {
            var stuffObject = prefab.GetComponent<StuffObject>();
            var stuffContainerData = new Diaco.Manhatan.Structs.StuffContinerData
                {group = stuffObject.GetGroup(), name = stuffObject.GetName(), prefab = prefab};
            if (stuffs.Contains(stuffContainerData)) continue;
            stuffs.Add(stuffContainerData);
        }

        Prefabs = new List<GameObject>();
    }

    [Searchable()] [PropertyOrder(1)] public List<Diaco.Manhatan.Structs.StuffContinerData> stuffs;
    public List<GameObject> beds;
    public List<GameObject> carpets;
    public List<GameObject> sofas;
    public List<GameObject> smallSofa;
    public List<GameObject> signs;
    public List<GameObject> tv;
    public List<GameObject> wallDecor;
    public List<GameObject> diningTable;
    public List<GameObject> hallTable;
    public List<GameObject> tvDesk;
    public List<GameObject> looster;
    public List<GameObject> kitchen;
    public List<GameObject> baths;
    public List<GameObject> doors;
    public List<GameObject> entrancedoors;
    public List<GameObject> normalDecor;
    public List<GameObject> toiletTable;
    public List<GameObject> wallHanging;
    public List<GameObject> walls;
    public List<GameObject> backwall;


    public void AddToStuffs()
    {
        if (beds.Count > 0)
        {
            Prefabs.AddRange(beds);
        }

        if (carpets.Count > 0)
        {
            Prefabs.AddRange(carpets);
        }

        if (sofas.Count > 0)
        {
            Prefabs.AddRange(sofas);
        }

        if (signs.Count > 0)
        {
            Prefabs.AddRange(signs);
        }

        if (tv.Count > 0)
        {
            Prefabs.AddRange(tv);
        }

        if (wallDecor.Count > 0)
        {
            Prefabs.AddRange(wallDecor);
        }

        if (diningTable.Count > 0)
        {
            Prefabs.AddRange(diningTable);
        }

        if (hallTable.Count > 0)
        {
            Prefabs.AddRange(hallTable);
        }

        if (tvDesk.Count > 0)
        {
            Prefabs.AddRange(tvDesk);
        }

        if (looster.Count > 0)
        {
            Prefabs.AddRange(looster);
        }

        if (smallSofa.Count > 0)
        {
            Prefabs.AddRange(smallSofa);
        }

        if (kitchen.Count > 0)  
        {
            Prefabs.AddRange(kitchen);
        }
        
        if (baths.Count > 0)  
        {
            Prefabs.AddRange(baths);
        }
        
        if (doors.Count > 0)  
        {
            Prefabs.AddRange(doors);
        }        
        
        if (entrancedoors.Count > 0)  
        {
            Prefabs.AddRange(entrancedoors);
        }
        
        if (normalDecor.Count > 0)  
        {
            Prefabs.AddRange(normalDecor);
        }
        
        if (toiletTable.Count > 0)  
        {
            Prefabs.AddRange(toiletTable);
        }
        
        if (wallHanging.Count > 0)  
        {
            Prefabs.AddRange(wallHanging);
        }

        if (walls.Count > 0)
        {
            Prefabs.AddRange(walls);
        }        
        if (backwall.Count > 0)
        {
            Prefabs.AddRange(walls);
        }
    }
}