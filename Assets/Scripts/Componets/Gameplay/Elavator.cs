using System;

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
namespace Diaco.Manhatan
{
    public class Elavator : MonoBehaviour
    {
        public Transform PositionForLock;
        public Transform PositionForLook;
        public TextMeshProUGUI DisplayPanel_text;
        public Image Arrow;

        public Button OkFloor_button;
        public Button Close_button;

        // Manager manager;
        private Animation DoorAniamtion;
        private bool Isopened = false;
        private bool IsLookToPad = false;
        private PersonController personController;
        public void Start()
        {
            DoorAniamtion = GetComponent<Animation>();
            //manager = FindObjectOfType<Manager>();
            personController = FindObjectOfType<PersonController>();
            OkFloor_button.onClick.AddListener(PressOK);
         
            Close_button.onClick.AddListener(() =>
            {
                CloseDoor();
            });
        }


        public void SetDisplay(string num)
        {
            if (DisplayPanel_text.text == "OK" || DisplayPanel_text.text == "Close")
                DisplayPanel_text.text = "";
            if (DisplayPanel_text.text.Length < 3)
                DisplayPanel_text.text += num;
            else
                DisplayPanel_text.text = num;
        }
        private void PressOK()
        {
            int num = Convert.ToInt32(DisplayPanel_text.text);
            if (Manager.singleton.CheckFloorInElavator(num))
            {
                CloseDoor();
                DisableViwePersonToNumPad();
                DisplayPanel_text.text = "OK";
                Arrow.gameObject.SetActive(true);
                DOVirtual.Float(0, num, num, (x) =>
                {
                    DisplayPanel_text.text = "Floor:" + x.ToString("0");
                }).OnComplete(() =>
                {
                    Manager.singleton.LoadScene(3);
                    
                    DOVirtual.DelayedCall(3, () =>
                    {
                        
                        DisplayPanel_text.text = "";
                        Arrow.gameObject.SetActive(false);
                    });
                }).SetEase(Ease.Linear);

            }
        }

        public void OpenDoor()
        {

            if (Isopened == false)
            {
                DoorAniamtion.Play("OpenElavator", PlayMode.StopAll);
                Isopened = true;
            }

        }
        public void CloseDoor()
        {

            if (Isopened == true)
            {
                DoorAniamtion.Play("CloseElavator", PlayMode.StopAll);
                Isopened = false;
              //  Debug.Log("Close Door");
            }

        }
        public void ViwePersonLockToNumPad()
        {
            if (personController == null)
                personController = FindObjectOfType<PersonController>();

            if (IsLookToPad == false)
            {
                IsLookToPad = true;
                
                if (personController.IsLookSomething == false)
                {
                    personController.IsLookSomething = true;
                    personController.transform.DOMove(PositionForLock.position, 0.5f);
                    personController.transform.DOLookAt(PositionForLook.position, 0.5f);

                  //  Debug.Log("AAAAAAA");
                }
                
            }
            else if (IsLookToPad == true)
            {
                DisableViwePersonToNumPad();
            }
        }
        public void DisableViwePersonToNumPad()
        {
            IsLookToPad = false;
            
           
            if (personController.IsLookSomething == true)
                personController.IsLookSomething = false;
            

        }
    }
}