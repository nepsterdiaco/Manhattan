using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Shapes;
using TMPro;
using DG.Tweening;
using Sirenix.OdinInspector;
using Diaco.Manhatan.Structs;
namespace Diaco.Manhatan
{
    public class Manager : MonoBehaviour
    {
        public _Phase GamePhase;
        public UserInfo UserInformation;
        public  static Manager singleton;

        [SerializeField] private Camera WorldMap_Cam;
        [SerializeField] private FadeEffect FadeEffect_UI;
        [SerializeField] private Canvas WorldMap_UI;
       // [SerializeField] private HUD HUD_UI;
       // [SerializeField] private BuildingInfo_UI InfoElementPrefab;
       // [SerializeField] private TextMeshProUGUI UserInfo_text;
        //[SerializeField] private RectTransform Content_info;
      //  [SerializeField] private Disc Point_shape, point2_shape;
       // [SerializeField] private Line Line_shape;

        #region Property
        [SerializeField] Transform buildingTransformSelected;
        public Transform TransformBuildingSelected { set { buildingTransformSelected = value; } get { return buildingTransformSelected; } }

        [SerializeField] private string buildingname;
        public string NameBuildingSelected { set { buildingname = value; } get { return buildingname; } }

        [SerializeField]private int numfloor;
        public int NumberFloorSelected { set { numfloor = value; } get { return numfloor; } }

        [SerializeField]private int unitselected;
        public int NumberUnitSelected
        {

            set
            {
                unitselected = value;


            }
            get { return unitselected; }
        }
        public List<UserAppartementData> AppartementsSelectedInFloor { set; get; } = new List<UserAppartementData>();

        #endregion
        private RoomGenerator roomGenerator;
        private List<BuildingInfo_UI> temp_ui = new List<BuildingInfo_UI>(10);
        
        private void Awake()
        {
            if (singleton == null)
            {
            
                singleton = this;                
            }

        }
        private void Start()
        {
            roomGenerator = GetComponent<RoomGenerator>();
            roomGenerator.OnSpawnedRoom += RoomGenerator_OnSpawnedRoom;
            
          
        }
        public void HightlightBuilding(string name)
        {
            for (int i = 0; i < BuildingManager.buildings.Count; i++)
            {
                for (int j = 0; j < UserInformation.userBuildings.Count; j++)
                {
                    var buildingName = UserInformation.userBuildings[j].buildingName;
                    if (BuildingManager.buildings[i].info.Name == buildingName)
                    {
                        BuildingManager.buildings[i].DOFlicker();
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
           // ClearBuildingInfoInUI();
            for (int i = 0; i < UserInformation.userBuildings.Count; i++)
            {
                var building_name = UserInformation.userBuildings[i].buildingName;
                if (building_name == name)
                {
                    NameBuildingSelected = name;
                    TransformBuildingSelected = buildingTransform;
                  //  SpawnBuildingInfoInUI(building_name);
                   // Point_Line_SetPositions(buildingTransform.position);
                   // Point_Line_Show(true);
                   
                }
            }
        }
       /* [Obsolete]
        public void SpawnBuildingInfoInUI(string buildingname)
        {
            for (int i = 0; i < BuildingManager.buildings.Count; i++)
            {
                var name = BuildingManager.buildings[i].info.Name;
                var info = BuildingManager.buildings[i].info.Information;
                if (name == buildingname)
                {
                    var element = Instantiate(InfoElementPrefab, Content_info);
                    element.SetElement(name, info);
                    temp_ui.Add(element);
                }
            }
        }
        [Obsolete]
        public void ClearBuildingInfoInUI()
        {
            for (int i = 0; i < temp_ui.Count; i++)
            {
                // Debug.Log("AAA" + temp_ui.Count);
                Destroy(temp_ui[i].gameObject);
            }
            temp_ui.Clear();
        }
        [Obsolete]
        public void Point_Line_SetPositions(Vector3 start)
        {
            Point_shape.transform.position = start;
            Line_shape.Start = start;
            Line_shape.End = point2_shape.transform.position;
        }
        [Obsolete]
        public void Point_Line_Show(bool show)
        {
            this.Point_shape.enabled = show;
            this.point2_shape.enabled = show;
            this.Line_shape.enabled = show;
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
        }*/
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
        
        public void LoadScene(int id)
        {
           // FadeIn();
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
            SceneManager.LoadSceneAsync(id, LoadSceneMode.Single);
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }
        private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode loadsceneMode)
        {
            if (scene.buildIndex != 1)
            {
                this.WorldMap_UI.GetComponent<CanvasGroup>().alpha = 0;
                this.WorldMap_Cam.gameObject.SetActive(false);
               // this.HUD_UI.GetComponent<CanvasGroup>().alpha = 1;
               // Point_Line_Show(false);
            }
            else
            {
                this.WorldMap_Cam.transform.position = new Vector3(3.6f, 58f, -73f);
                this.WorldMap_UI.GetComponent<CanvasGroup>().alpha = 1;
                this.WorldMap_Cam.gameObject.SetActive(true);
              ///  this.HUD_UI.GetComponent<CanvasGroup>().alpha = 0;
            }
            ChangePhase(scene.buildIndex);
           //FadeOut();
            Debug.Log($"Scenes{scene.name}");
        }

        public void LoadRoom( )

        {
            //this.unitselected = unit;
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
                            roomGenerator.LoadRoom(group, room);
                        }
                    }
                }
            }
        }
        public void WorldMapCameraMoveEffect()
        {
            //Point_Line_Show(false);
            WorldMap_Cam.transform.DOMove(TransformBuildingSelected.position, 1).OnComplete(() => {
                LoadScene(2);
            });
            FadeEffect_UI.FadeIn(1);
        }
        public void ResetWorld()
        {
            LoadScene(1);
        }
        public void ExitApp()
        {
            Application.Quit();
        }
        /*[Obsolete]
        public void FadeIn()
        {
            FadeEffect_UI.FadeIn(1);
        }
        [Obsolete]
        public void FadeOut()
        {
            FadeEffect_UI.FadeOut(1);
        }*/
        public void ChangePhase(int index)
        {
            if (index == 0)
            {
                GamePhase = _Phase.Login;
            }
            else if (index == 1)
            {
                GamePhase = _Phase.WorldMap;
            }
            else if (index == 2)
            {
                GamePhase = _Phase.Lobby;
            }
            else if (index == 3)
            {
                GamePhase = _Phase.Hall;
            }
            else if (index == 4)
            {
                GamePhase = _Phase.Room;
            }
        }
        #region Trigger
        private void RoomGenerator_OnSpawnedRoom()
        {
            /////////////FindObjectOfType<RoomObject>().transform.position = PlaceSpawnRoom.position;****************************
            /////ChangePlacePlayer("room");*******************

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