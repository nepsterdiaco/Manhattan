
using UnityEngine;


using UnityEngine.UI;
using TMPro;

namespace Diaco.Manhatan.UI
{
    public class WorldMapUI :BaseUIPanel
    {
        [SerializeField] private Image imageBuilding_Image;
        [SerializeField] private TextMeshProUGUI buildingName_Text;
        [SerializeField] private TextMeshProUGUI buildingInfo_Text;
        [SerializeField] private TextMeshProUGUI buildingFloors_Text;
        [SerializeField] private TextMeshProUGUI buildingUint_Text;

        [SerializeField] private TextMeshProUGUI userOwneruint_Text;

        [SerializeField] private BaseUIPanel NextMenu;
        [SerializeField] private BaseUIPanel BackMenu;
      

      
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SelectBuildin();
            }
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Menu();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Quit();
            }

        }
        public void SetBuildingInfo(Structs.BuildingData data)
        {
            this.imageBuilding_Image.sprite = data.ImageBuilding;
            this.buildingName_Text.text = data.Name;
            this.buildingInfo_Text.text = data.Information;
            this.buildingFloors_Text.text = (data.Floor).ToString();
            this.buildingUint_Text.text = (data.Uint).ToString();

        }
        public void SetUnitPlayerInThisBuilding(int Count)
        {
            userOwneruint_Text.text = $"YOU HAVE{Count} UNIT IN THIS BUILDING";
        }
        private void SelectBuildin()
        {
            Manager.singleton.GotoLobbyBuildingWithCameraEffectAndSceneLoad(2);
            Debug.Log("Select This Building And Go To Lobby");
        }
        private void Menu()
        {
            if (!NextMenu.gameObject.activeSelf)
            {
                this.gameObject.SetActive(false);
                NextMenu.gameObject.SetActive(true);

            }
 
        }
        private void Quit()
        {
            if (!BackMenu.gameObject.activeSelf)
            {
                this.gameObject.SetActive(false);
                BackMenu.gameObject.SetActive(true);
            }
        }
    }

}

