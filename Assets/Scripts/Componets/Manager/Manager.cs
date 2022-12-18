using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Diaco.Manhatan.Structs;
using Diaco.Manhatan.UI;

namespace Diaco.Manhatan
{
    public class Manager : MonoBehaviour
    {
        public _Phase GamePhase;
        public UserInfo UserInformation;
        public  static Manager singleton;

        [SerializeField] private Camera WorldMap_Cam;
        
        [SerializeField] private WorldMapUI WorldMap_UI;
        
        [SerializeField] private Loading Loading_UI;

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
       // private List<BuildingInfo_UI> temp_ui = new List<BuildingInfo_UI>(10);
        
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
        public void HightlightPlayerBuildings()
        {
            for (int i = 0; i < BuildingManager.buildings.Count; i++)
            {
                for (int j = 0; j < UserInformation.userBuildings.Count; j++)
                {
                    var buildingName = UserInformation.userBuildings[j].buildingName;
                    if (BuildingManager.buildings[i].info.Name == buildingName)
                    {
                        BuildingManager.buildings[i].DOFlicker();
                        BuildingManager.buildings[i].EnableBuildingMarker();
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
        public void UserSelectedBuilding(string name, Transform buildingTransform, BuildingData buildingdata)
        {
           // ClearBuildingInfoInUI();
            for (int i = 0; i < UserInformation.userBuildings.Count; i++)
            {
                var building_name = UserInformation.userBuildings[i].buildingName;
                
                if (building_name == name)
                {
                    var unit_count = UserInformation.userBuildings[i].appartements.Count;
                    NameBuildingSelected = name;
                    TransformBuildingSelected = buildingTransform;
                    WorldMap_UI.SetBuildingInfo(buildingdata);
                    WorldMap_UI.SetUnitPlayerInThisBuilding(unit_count);
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

        public  void LoadScene(int id)
        {
            // FadeIn();
            StartCoroutine(loadscene(id)); 
            
        }
         private IEnumerator loadscene(int id)
         {
            Loading_UI.Show(true);
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
             var c = SceneManager.LoadSceneAsync(id);
          //  c.allowSceneActivation = false;
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
            int i = 0;
            while (c.progress < 1.0f)
            {
                Loading_UI.SetRadialPrograssbar(i);              
                i++;
                if (i == Loading_UI.SheetCount - 1)
                    i = 0;
                yield return null;
            }
        }
        private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode loadsceneMode)
        {
            Loading_UI = FindObjectOfType<Loading>();

            if (scene.buildIndex != 1)
            {

            }
            else
            {
                WorldMap_Cam = FindObjectOfType<Camera>();
                WorldMap_UI = FindObjectOfType<WorldMapUI>();
                DOVirtual.DelayedCall(1, () => { HightlightPlayerBuildings(); });
            }
            ChangePhase(scene.buildIndex);
            Loading_UI.Show(false);
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
        public void GotoLobbyBuildingWithCameraEffectAndSceneLoad(int sceneIndex)
        {
            //Point_Line_Show(false);
            WorldMap_Cam.transform.DOMove(TransformBuildingSelected.position, 1).OnComplete(() => {
                LoadScene(sceneIndex);
            });
           // FadeEffect_UI.FadeIn(1);
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

            var roomspwaner = FindObjectOfType<RoomSpawner>();
            if (roomspwaner)
                roomspwaner.ActivePlayer();

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