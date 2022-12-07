using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Diaco.Manhatan.UI.WorldMap
{
    public class WorldMapUI : MonoBehaviour
    {
        [SerializeField] private Image imageBuilding_Image;
        [SerializeField] private TextMeshProUGUI buildingName_Text;
        [SerializeField] private TextMeshProUGUI buildingInfo_Text;
        [SerializeField] private TextMeshProUGUI buildingFloors_Text;
        [SerializeField] private TextMeshProUGUI buildingUint_Text;
        [SerializeField] private Button select_Button;
        [SerializeField] private Button Quit_Button;

    }
}
