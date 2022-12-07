using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using Diaco.Manhatan.Structs;
namespace Diaco.Manhatan.UI
{
    public class Login : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI ShowMessage_text;
        [SerializeField] private TMP_InputField Username_input;
        [SerializeField] private TMP_InputField Password_input;
        [SerializeField] private Button SignIn_Button;
        [SerializeField] private Button SignUp_Button;
        [SerializeField] private Button ForgetPass_Button;

        [SerializeField] private Button Close_Button;
        void Start()
        {

            //Manager.singleton.FadeOut();
            SignIn_Button.onClick.AddListener(() =>
            {


                if (Username_input.text == "user" && Password_input.text == "pass")
                {
                    /*
                                        ///// Create Unit 
                                        UserAppartementData appartement_a = new UserAppartementData { roomGroup = "Royal_0", roomName = "R_2", floor = 5, unit = 1 };
                                        UserAppartementData appartement_b = new UserAppartementData { roomGroup = "Royal_0", roomName = "R_2", floor = 10, unit = 2 };
                                        UserAppartementData appartement_c = new UserAppartementData { roomGroup = "Royal_0", roomName = "R_2", floor = 10, unit = 3 };

                                        //// Add To list Appartements
                                        List<UserAppartementData> userAppartementData_temp = new List<UserAppartementData>();

                                        userAppartementData_temp.Add(appartement_a);
                                        userAppartementData_temp.Add(appartement_b);
                                        userAppartementData_temp.Add(appartement_c);

                                        //// Create Building
                                        List<UserBuildingData> userBuilding_temp = new List<UserBuildingData>();

                                        //// Add To list Buildings
                                        userBuilding_temp.Add(new UserBuildingData() { buildingName = "A", appartements = userAppartementData_temp });
                                        userBuilding_temp.Add(new UserBuildingData() { buildingName = "B", appartements = userAppartementData_temp });

                                        //// Create Data
                                        Manager.singleton.UserInformation = new UserInfo { userName = "OmidPirhadi", userBuildings = userBuilding_temp };

                                        //// Set Data
                                        Manager.singleton.SetUserInfo();

                                        Manager.singleton.LoadScene(1);
                                        */
                    Debug.Log("Login");
                }
                else
                {
                    ShowMessage_text.enabled = true;
                    ShowMessage_text.text = "Error Login Faild";
                }

            });

        }
    }
}