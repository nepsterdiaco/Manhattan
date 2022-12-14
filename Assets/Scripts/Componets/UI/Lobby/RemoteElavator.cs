using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
namespace Diaco.Manhatan.UI
{
    public class RemoteElavator : BaseUIPanel
    {
        [SerializeField] private TextMeshProUGUI RemoteDisplay;
        [SerializeField] private CanvasGroup ArrowsGroup;
        [SerializeField] private LoopType loopType;
        [SerializeField] private Ease easeType;
        [SerializeField] private float speedFlicker = 0.5f;

        private Tween tweenArrow;

        public int CurrentFloor { set; get;}
        public static RemoteElavator instance;

        public void OnEnable()
        {
            if (instance == null)
                instance = this;

        }
        public void ShowRemote(bool show)
        {
            if (show)
                this.gameObject.SetActive(show);
            else
                this.gameObject.SetActive(show);
        }
        public void SetDisplay(char value)
        {
            if (value == 'O')
            {
                Elevator.instanc.PressOK(CurrentFloor);
            }
            else if (value == 'C')
            {
                RemoteDisplay.text = "";
                CurrentFloor = 0;
            }
            else
            {
                if (RemoteDisplay.text.Length <= 3)
                {
                    RemoteDisplay.text += value;
                    var floor = RemoteDisplay.text;
                    CurrentFloor = System.Convert.ToInt16(floor);
                }
                else
                {
                    RemoteDisplay.text = "";
                    CurrentFloor = 0;
                }
            }
        }
        public void DisplayCurrentFloor(float value)
        {
            RemoteDisplay.text = value.ToString("0");

        }
        public void EnableArrowFlicker(bool enable)
        {
            if (enable)
            {
                if (tweenArrow != null)
                    tweenArrow.Kill(false);
                tweenArrow = DOVirtual.Float(0, 1, speedFlicker, (a) =>
                {
                    ArrowsGroup.alpha = a;
                }).SetEase(easeType).SetLoops(100, loopType);
            }
            else
            {
                if (tweenArrow != null)
                    tweenArrow.Kill(false);
            }
        }
    }

}
