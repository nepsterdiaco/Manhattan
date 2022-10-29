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
    [PropertyOrder(-1)]
    [Button]
    public void ClearAllCollection()
    {
        beds.Clear();
        carpets.Clear();
        sofas.Clear();
        signs.Clear();
        tv.Clear();
        wallDecor.Clear();
        diningTable.Clear();
        hallTable.Clear();
        tvDesk.Clear();
        looster.Clear();
        smallSofa.Clear();
        kitchen.Clear();
        walls.Clear();
    }

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

    [Searchable( )]
    [PropertyOrder(1)]
    public List<Diaco.Manhatan.Structs.StuffContinerData> stuffs;
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
    public List<GameObject> walls;
    
    
    public void AddToStuffs()
    {
        Prefabs.AddRange(beds);
        Prefabs.AddRange(carpets);
        Prefabs.AddRange(sofas);
        Prefabs.AddRange(signs);
        Prefabs.AddRange(tv);
        Prefabs.AddRange(wallDecor);
        Prefabs.AddRange(diningTable);
        Prefabs.AddRange(hallTable);
        Prefabs.AddRange(tvDesk);
        Prefabs.AddRange(looster);
        Prefabs.AddRange(smallSofa);
        Prefabs.AddRange(kitchen);
        Prefabs.AddRange(walls);
    }


}



