using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using Diaco.Manhatan.Structs;
namespace Diaco.Manhatan.UI
{
    public class Login : MonoBehaviour
    {
        [SerializeField] private CanvasGroup MessageBoxRect_CanvasGroup;
        [SerializeField] private TextMeshProUGUI ContextMessage_text;
        [SerializeField] private TMP_InputField Username_input;
        [SerializeField] private TMP_InputField Password_input;
       
        [SerializeField] private float DurationShowMessageBox = 0.5f;
        [SerializeField] private Button SignIn_Button;
        [SerializeField] private Button SignUp_Button;
        [SerializeField] private Button ForgetPass_Button;

        [SerializeField] private Button Close_Button;
        void Start()
        {

            //Manager.singleton.FadeOut();
            SignIn_Button.onClick.AddListener(Signin);
            SignUp_Button.onClick.AddListener(Signup);
            ForgetPass_Button.onClick.AddListener(Forgetpassword);
            Close_Button.onClick.AddListener(Close);

        }

        private void Signin()
        {
            if (Username_input.text == "user" && Password_input.text == "pass")
            {

                ///// Create Unit 
                UserAppartementData appartement_a = new UserAppartementData { roomGroup = "Royal_0", roomName = "R_1", floor = 5, unit = 1 };
                UserAppartementData appartement_b = new UserAppartementData { roomGroup = "Royal_0", roomName = "R_2", floor = 10, unit = 2 };
                UserAppartementData appartement_c = new UserAppartementData { roomGroup = "Royal_0", roomName = "R_3", floor = 10, unit = 3 };

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



                Manager.singleton.LoadScene(1);

                Debug.Log("Login");
            }
            else
            {
                MessageBox("Error Login Faild");

            }
        }
        private void Signup()
        {
            MessageBox("Comin Soon.....SignUp");
        }
        private void Forgetpassword()
        {
            MessageBox("Comin Soon.....Forgetpass");
        }
        private void Close()
        {
            MessageBox("Comin Soon.....Close");
        }
        private void MessageBox(string context)
        {
            ContextMessage_text.text = context;
            ShowMessageBox(true);
            DOVirtual.DelayedCall(DurationShowMessageBox + 0.5f, () =>
            {
                ShowMessageBox(false);
            });
        }

        private Tween tween;
        private void ShowMessageBox(bool show)
        {
            if (tween != null)
                tween.Kill();
            if (show)
               tween =  DOVirtual.Float(0, 1, DurationShowMessageBox, (alpha) => { MessageBoxRect_CanvasGroup.alpha = alpha; });
            else
                tween =  DOVirtual.Float(1, 0, DurationShowMessageBox, (alpha) => { MessageBoxRect_CanvasGroup.alpha = alpha; });
        }
    }
}