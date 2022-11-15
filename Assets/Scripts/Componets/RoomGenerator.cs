using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using Sirenix.OdinInspector;

public class RoomGenerator : MonoBehaviour
{


    public RoomsContiner RoomsContainerData;
    public StuffContiner StuffsContainerData;
    public Diaco.Manhatan.Structs.RoomData roomData;

    private RoomObject room_gameobject;


    [Button("InitializeRoom", ButtonSizes.Medium)]
 
    public void InitializeRoom()
    {
        StartCoroutine(FindStuff());
    }
    private IEnumerator FindStuff()
    {
        
       
        if (room_gameobject == null)
            room_gameobject = FindObjectOfType<RoomObject>();

        roomData.stuffs = new List<Diaco.Manhatan.Structs.StuffInRoom>();
   
        //  var list_stuff_in_room = FindObjectsOfType<StuffObject>().ToList();


        var list_stuff_in_room = room_gameobject.GetComponentsInChildren<StuffObject>().ToList();
       
        yield return new WaitForSecondsRealtime(0.1f);
        for (int i = 0; i < list_stuff_in_room.Count; i++)
        {
            var stuffdata = list_stuff_in_room[i].Data;
            var transform_stuff = list_stuff_in_room[i].transform;
            roomData.stuffs.Add(new Diaco.Manhatan.Structs.StuffInRoom
            {
                group = stuffdata.group,
                name = stuffdata.name,
                stuffGameObject = list_stuff_in_room[i].gameObject,
                position = transform_stuff.position,
                rotation = transform_stuff.rotation,
                scale = transform_stuff.lossyScale
            });
            
            yield return null;

        }

        
    }




    [Button("RandomChangeStuff", ButtonSizes.Medium)]
    private void RandomChangeStuff()
    {
        StartCoroutine(RandomChangeStuff_coroutine());
    }
    private IEnumerator RandomChangeStuff_coroutine()
    {
        for (int i = 0; i < roomData.stuffs.Count; i++)
        {
            if (!roomData.stuffs[i].Lock)
            {
                var id_stuff = roomData.stuffs[i].group;
                var stuff_position = roomData.stuffs[i].position;
                var stuff_rotation = roomData.stuffs[i].rotation;
                Destroy(roomData.stuffs[i].stuffGameObject);
                var stuff_list_by_id = StuffsContainerData.stuffs.Where(s => s.group == id_stuff).ToList();
                var random_stuff_Select_index = UnityEngine.Random.Range(0, stuff_list_by_id.Count);
                var prefab_stuff = stuff_list_by_id[random_stuff_Select_index].prefab;
                yield return new WaitForSecondsRealtime(0.01f);
                Instantiate(prefab_stuff, stuff_position, stuff_rotation, room_gameobject.transform);
                yield return new WaitForSecondsRealtime(0.01f);
            }
        }
        yield return StartCoroutine(FindStuff());
        yield return new WaitForSecondsRealtime(0.01f);
        Debug.Log("RandomChanged");
    }

    [Button("SaveRoom", ButtonSizes.Medium)]
    private void SaveRoom()
    {

        var json = JsonUtility.ToJson(roomData);
        if (File.Exists(Application.dataPath + "//Containers//Rooms//" + roomData.name + ".json"))
        {
            File.Delete(Application.dataPath + "//Containers//Rooms//" + roomData.name + ".json");
        }
        File.WriteAllText(Application.dataPath + "//Containers//Rooms//" + roomData.name + ".json", json);
    }
   
    private IEnumerator ArrangeStuffInRoom(List<Diaco.Manhatan.Structs.StuffInRoom> stuffs, Transform parent)
    {
       //Debug.Log("1");
        for (int i = 0; i < stuffs.Count; i++)
        {
           // Debug.Log("2");
            var stuff_group = stuffs[i].group;
            var stuff_name = stuffs[i].name;
            var stuff_pos = stuffs[i].position;
            var stuff_rot = stuffs[i].rotation;
            var list_filter_by_group = StuffsContainerData.stuffs.Where(s => s.group == stuff_group).ToList();
            
            yield return new WaitForSecondsRealtime(0.01f);
            for (int j = 0; j < list_filter_by_group.Count; j++)
            {
             //   Debug.Log("3");
                if (list_filter_by_group[j].name == stuff_name)
                {

                    Instantiate(list_filter_by_group[j].prefab, stuff_pos, stuff_rot, parent);
                  //  Debug.Log("4");
                }
                

            }
            yield return new WaitForSecondsRealtime(0.01f);
        }

        yield return new WaitForSecondsRealtime(0.01f);
        TryToSpawnRoom = false;
        //Debug.Log("Room Arranged");
        Handler_OnSpawnedRoom();
    }
    [Button("TestLoadRoom", ButtonSizes.Medium)]
    public  void LoadRoom(string group, string RoomName)
    {
        var list_filter_by_group = RoomsContainerData.Rooms.Where(r => r.group == group).ToList();
        for (int i = 0; i < list_filter_by_group.Count; i++)
        {
            if (list_filter_by_group[i].name == RoomName)
            {
                var R_D = JsonUtility.FromJson<Diaco.Manhatan.Structs.RoomData>(list_filter_by_group[i].roomData.text);
                var room = Instantiate(list_filter_by_group[i].RoomPrefab);
                Debug.Log("Room Spawned And Wait For Arrange");
                StartCoroutine(ArrangeStuffInRoom(R_D.stuffs, room.transform));

            }
        }
    }
    private bool TryToSpawnRoom = false;
    public GameObject room2;
    public void  LoadRoom(string group, string RoomName , Transform placeSpawn)
    {
        if (TryToSpawnRoom == false)
        {
            TryToSpawnRoom = true;
            var list_filter_by_group = RoomsContainerData.Rooms.Where(r => r.group == group).ToList();
            for (int i = 0; i < list_filter_by_group.Count; i++)
            {

                if (list_filter_by_group[i].name == RoomName)
                {
                    var R_D = JsonUtility.FromJson<Diaco.Manhatan.Structs.RoomData>(list_filter_by_group[i].roomData.text);
                    room2 = Instantiate(list_filter_by_group[i].RoomPrefab);
                    StartCoroutine(ArrangeStuffInRoom(R_D.stuffs, room2.transform));

                }
            }
        }
    }


    private Action spawnedroom;
    public event Action OnSpawnedRoom
    {
        add { spawnedroom += value; }
        remove { spawnedroom -= value; }
    }
    protected void Handler_OnSpawnedRoom()
    {
        if(spawnedroom !=null)
        {
            spawnedroom();
        }
    }
}
