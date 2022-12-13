
using UnityEngine;
using DG.Tweening;
using Diaco.Manhatan.UI;
namespace Diaco.Manhatan
{
    public class Elavator : MonoBehaviour
    {
        public static Elavator instanc;
        private Animation DoorAniamtion;
        private bool Isopened = false;
        public void Start()
        {
            if (instanc == null)
                instanc = this;
            DoorAniamtion = GetComponent<Animation>();
        }
        public void PressOK(int num)
        {
            if (num != 0)
            {
                if (Manager.singleton.CheckFloorInElavator(num))
                {
                    CloseDoor();
                    RemoteElavator.instance.EnableArrowFlicker(true);
                    DOVirtual.Float(0, num, num, (floor) =>
                    {
                        RemoteElavator.instance.DisplayCurrentFloor(floor);
                    }).OnComplete(() =>
                    {
                        RemoteElavator.instance.EnableArrowFlicker(false);
                        Manager.singleton.LoadScene(3);
                    }).SetEase(Ease.Linear);
                }
            }
        }
        public void OpenDoor()
        {

            if (Isopened == false)
            {
                //if (!DoorAniamtion.IsPlaying("CloseElavator") && !DoorAniamtion.IsPlaying("OpenElavator"))
                //{
                    DoorAniamtion.CrossFade("OpenElavator");
                    Isopened = true;
               // }
            }

        }
        public void CloseDoor()
        {

            if (Isopened == true)
            {
               // if (!DoorAniamtion.IsPlaying("CloseElavator") && !DoorAniamtion.IsPlaying("OpenElavator"))
                //{
                    DoorAniamtion.CrossFade("CloseElavator");
                    Isopened = false;
              //  }
             
            }

        }
    }
}