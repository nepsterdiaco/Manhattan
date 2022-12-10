
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Diaco.Manhatan.UI
{
    public class WorldMapUI : MonoBehaviour
    {
        [SerializeField] private Image imageBuilding_Image;
        [SerializeField] private TextMeshProUGUI buildingName_Text;
        [SerializeField] private TextMeshProUGUI buildingInfo_Text;
        [SerializeField] private TextMeshProUGUI buildingFloors_Text;
        [SerializeField] private TextMeshProUGUI buildingUint_Text;

        [SerializeField] private TextMeshProUGUI userOwneruint_Text;


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SelectBuildin();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Setting();
            }
            if (Input.GetKeyDown(KeyCode.F1))
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

        private void SelectBuildin()
        {
            Debug.Log("Select This Building And Go To Lobby");
        }
        private void Setting()
        {
            Debug.Log("Open Setting Panel");
        }
        private void Quit()
        {
            Debug.Log("Quit App");
        }
    }

}

