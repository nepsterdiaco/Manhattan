using System;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
using TMPro;
using DG.Tweening;
using Diaco.Manhatan.Structs;
namespace Diaco.Manhatan
{
    public class Manager : MonoBehaviour
    {

        public _Phase GamePhase;
        public UserInfo UserInformation;

        [SerializeField] private Camera WorldMap_Cam;
        [SerializeField] private GameObject FirstPersonPlayer;

        [SerializeField] private Transform PlaceSpawnRoom;
        [SerializeField] private Transform[] SpawnPlacePerson;

        public FadeEffect FadeEffect_UI;
        [SerializeField] private Canvas WorldMap_UI;
        [SerializeField] private HUD HUD_UI;
        [SerializeField] private BuildingInfo_UI InfoElementPrefab;
        [SerializeField] private TextMeshProUGUI UserInfo_text;
        [SerializeField] private RectTransform Content_info;
        [SerializeField] private Disc Point_shape, point2_shape;
        [SerializeField] private Line Line_shape;

        #region Property
        public Transform TransformBuildingSelected { set; get; }
        public string NameBuildingSelected { set; get; }
        public int NumberFloorSelected { set; get; }

        private int unitselected;
        public int NumberUnitSelected
        {

            set
            {
                unitselected = value;
                if (unitselected != -1)
                {
                   // Debug.Log("Unit Selected Unit:" + unitselected);
                    LoadRoom();

                }

            }
            get { return unitselected; }
        }
        public List<UserAppartementData> AppartementsSelectedInFloor { set; get; } = new List<UserAppartementData>();

        #endregion

        private BuildingManager buildingManager;
        private RoomGenerator roomGenerator;
        private List<BuildingInfo_UI> temp_ui = new List<BuildingInfo_UI>(10);
        public  static Manager singleton;



        private void Awake()
        {
            GameObject.DontDestroyOnLoad(this);
            if (singleton == null)
                singleton = this;
        }
        private void Start()
        {
           // Cursor.lockState = CursorLockMode.Locked;
            buildingManager = GetComponent<BuildingManager>();
            roomGenerator = GetComponent<RoomGenerator>();
            roomGenerator.OnSpawnedRoom += RoomGenerator_OnSpawnedRoom;
        }
        private void Update()
        {

            if (Input.GetKey(KeyCode.Escape))
            {
              //  ResetWorld();
            }
        }

      
        public void HightlightBuilding(string name)
        {
            for (int i = 0; i < buildingManager.buildings.Count; i++)
            {
                for (int j = 0; j < UserInformation.userBuildings.Count; j++)
                {
                    var buildingName = UserInformation.userBuildings[j].buildingName;
                    if (buildingManager.buildings[i].info.Name == buildingName)
                    {
                        buildingManager.buildings[i].DOFlicker();
                        // Debug.Log("HHHHH");
                    }
                }
            }
        }
        public bool BuildingOwner(string name)
        {
            bool owner = false;
            for (int i = 0; i < UserInformation.userBuildings.Count; i++)
            {
                var building_name = UserInformation.userBuildings[i].buildingName;
                if(building_name == name)
                {
                    owner = true;
                    break;
                }
            }
            return owner;
        }

        public void SelectBuilding(string name, Transform buildingTransform)
        {
            ClearBuildingInfoInUI();
            for (int i = 0; i < UserInformation.userBuildings.Count; i++)
            {
                var building_name = UserInformation.userBuildings[i].buildingName;
                if (building_name == name)
                {
                    NameBuildingSelected = name;
                    TransformBuildingSelected = buildingTransform;



                    SpawnBuildingInfoInUI(building_name);
                    Point_Line_SetPositions(buildingManager.buildings[i].transform.position);
                    Point_Line_Show(true);
                   
                }
            }
        }
        public void SpawnBuildingInfoInUI(string buildingname)
        {
            for (int i = 0; i < buildingManager.buildings.Count; i++)
            {
                var name = buildingManager.buildings[i].info.Name;
                var info = buildingManager.buildings[i].info.Information;
                if (name == buildingname)
                {
                    var element = Instantiate(InfoElementPrefab, Content_info);
                    element.SetElement(name, info);

                    temp_ui.Add(element);
                }
            }


        }
        public void ClearBuildingInfoInUI()
        {
            for (int i = 0; i < temp_ui.Count; i++)
            {
                // Debug.Log("AAA" + temp_ui.Count);
                Destroy(temp_ui[i].gameObject);
            }
            temp_ui.Clear();
        }

        public void Point_Line_SetPositions(Vector3 start)
        {
            Point_shape.transform.position = start;
            Line_shape.Start = start;

            Line_shape.End = point2_shape.transform.position;
        }
        public void Point_Line_Show(bool show)
        {
            Point_shape.gameObject.SetActive(show);
            point2_shape.gameObject.SetActive(show);
            Line_shape.gameObject.SetActive(show);
        }
        public void SetUserInfo()
        {
            UserInfo_text.text = $" UserName : {UserInformation.userName}\r\n";


            for (int i = 0; i < UserInformation.userBuildings.Count; i++)
            {
                UserInfo_text.text += $"Building:{UserInformation.userBuildings[i].buildingName}\r\n";
                for (int j = 0; j < UserInformation.userBuildings[i].appartements.Count; j++)
                {
                    var appartemntname = UserInformation.userBuildings[i].appartements[j].roomName;
                    var appartemntfloor = UserInformation.userBuildings[i].appartements[j].floor;
                    var appartemntunit = UserInformation.userBuildings[i].appartements[j].unit;

                    UserInfo_text.text += $"Appartements:\r\n Name :{appartemntname} Floor:{appartemntfloor} Unit:{appartemntunit}\r\n";
                }


                HightlightBuilding(UserInformation.userBuildings[i].buildingName);
            }

        }


        public bool CheckFloorInElavator(int floor)
        {
            bool right = false;
            NumberFloorSelected = -1;
            AppartementsSelectedInFloor.Clear();
            for (int i = 0; i < UserInformation.userBuildings.Count; i++)
            {
                if (UserInformation.userBuildings[i].buildingName == NameBuildingSelected)
                {
                    for (int j = 0; j < UserInformation.userBuildings[i].appartements.Count; j++)
                    {
                        if (UserInformation.userBuildings[i].appartements[j].floor == floor)
                        {
                            NumberFloorSelected = floor;
                            AppartementsSelectedInFloor.Add(UserInformation.userBuildings[i].appartements[j]);
                            right = true;
                        }
                    }

                }
            }

            return right;

        }

        public void ChangePlacePlayer(string place)
        {
            Handler_OnChangePlace(place);
            //Debug.Log("Change Position");
            FadeEffect_UI.FadeOut(1);
            if (place == "map")
            {

            }
            else if (place == "lobby")
            {

                 WorldMap_UI.gameObject.SetActive(false);
                WorldMap_Cam.gameObject.SetActive(false);
                HUD_UI.gameObject.SetActive(true);
                Point_Line_Show(false);
                FirstPersonPlayer.transform.position = SpawnPlacePerson[1].position;
                FirstPersonPlayer.transform.rotation = SpawnPlacePerson[1].rotation;
                FirstPersonPlayer.SetActive(true);
                GamePhase = _Phase.Lobby;
            }

            else if (place == "hall")
            {
     

                FirstPersonPlayer.SetActive(false);
                FadeEffect_UI.FadeIn(1).OnComplete(() => {
                    FirstPersonPlayer.transform.position = SpawnPlacePerson[2].position;
                    FirstPersonPlayer.transform.rotation = SpawnPlacePerson[2].rotation;
                    FadeEffect_UI.FadeOut(1).OnComplete(() => {
                        FirstPersonPlayer.SetActive(true);

                    });
                });
                GamePhase = _Phase.Hall;
            }
            else if (place == "room")
            {
                FirstPersonPlayer.SetActive(false);
                FadeEffect_UI.FadeIn(1).OnComplete(() => {
                    FirstPersonPlayer.transform.position = SpawnPlacePerson[3].position;
                    FirstPersonPlayer.transform.rotation = SpawnPlacePerson[3].rotation;
                    FadeEffect_UI.FadeOut(1).OnComplete(() => {
                        FirstPersonPlayer.SetActive(true);
                    });
                });
                Point_Line_Show(false);
                GamePhase = _Phase.Room;
            }


            
        }
        public void LoadRoom()
        {
            //Debug.Log($"Begin Load Room:Building{NameBuildingSelected}.... Floor:{NumberFloorSelected}....Unit:{unitselected}");

            for (int i = 0; i < UserInformation.userBuildings.Count; i++)
            {
              //  Debug.Log("1");
                var building_name = UserInformation.userBuildings[i].buildingName;
                if (building_name == NameBuildingSelected)
                {
                  //  Debug.Log("2");
                    var appartemets = UserInformation.userBuildings[i].appartements;
                    for (int j = 0; j < appartemets.Count; j++)
                    {
                    //    Debug.Log("3");
                        var floor = appartemets[j].floor;
                        var unit = appartemets[j].unit;
                        if (floor == NumberFloorSelected && unit == unitselected)
                        {
                         //   Debug.Log("4");
                            var group = appartemets[j].roomGroup;
                            var room = appartemets[j].roomName;
                           // Debug.Log("Find Room");
                            roomGenerator.LoadRoom(group, room, PlaceSpawnRoom);
                        }
                    }
                }
            }
        }


        public void WorldMapCameraMoveEffect()
        {
            Point_Line_Show(false);
            WorldMap_Cam.transform.DOMove(TransformBuildingSelected.position, 1).OnComplete(() => {
                ChangePlacePlayer("lobby");
            });
            FadeEffect_UI.FadeIn(1);
        }

        public void ResetWorld()
        {
            if (GamePhase == _Phase.Room)
            {
                Handler_OnChangePlace("");
                FirstPersonPlayer.SetActive(false);
                WorldMap_Cam.transform.position = new Vector3(3.6f, 58f, -73f);
                HUD_UI.gameObject.SetActive(false);
                var room_g = GetComponent<RoomGenerator>();
                if (room_g.room2 != null)
                    Destroy(room_g.room2.gameObject, 0.1f);

                WorldMap_UI.gameObject.SetActive(true);
                WorldMap_Cam.gameObject.SetActive(true);
            }
           /* if (Person != null)
                Destroy(Person.gameObject);*/
        }
        #region Trigger
        private void RoomGenerator_OnSpawnedRoom()
        {
            FindObjectOfType<RoomObject>().transform.position = PlaceSpawnRoom.position;
            ChangePlacePlayer("room");

        }
        #endregion
        #region Events
        private Action <string> onchageplace;
        public event Action<string> OnChangePlace
        {
            add { onchageplace += value; }
            remove { onchageplace -= value; }
        }
        protected void Handler_OnChangePlace(string nameplace)
        {
            if(onchageplace !=null)
            {
                onchageplace(nameplace);
            }
        }
        #endregion

    }


}