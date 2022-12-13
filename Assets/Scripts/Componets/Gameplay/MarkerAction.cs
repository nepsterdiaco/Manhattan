using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;
using Sirenix.OdinInspector;
namespace Diaco.Manhatan
{
    public class MarkerAction : MonoBehaviour
    {
        public string MakerContext;
        public string MarkerContextIdel;
        public TextMeshProUGUI DisplayContext_text;
        
        public bool InvokeWithKey = false;   
        public bool Inside
        {
            set; 
            get ; 
        }
        [ShowIfGroup("InvokeWithKey")]
        [BoxGroup("InvokeWithKey/Select Input Key")]
        public KeyCode keyCode;
        [BoxGroup("Action")]
        public UnityEvent ActionOnEnter;
        [BoxGroup("Action")]
        public UnityEvent ActionOnExit;
        private CanvasGroup canvasGroup;
        private Image markerlogo_billboard;
        private Image markerline_billboard;

        private void Start()
        {
            canvasGroup = GetComponentInChildren<CanvasGroup>();
            var billboards = GetComponentsInChildren<Image>();
            for (int i = 0; i < billboards.Length; i++)
            {
                if(billboards[i].name == "marker_image")
                {
                    markerlogo_billboard = billboards[i];
                }
                else if(billboards[i].name == "Line")
                {
                   markerline_billboard = billboards[i];
                }
            }
            
            Manager.singleton.OnChangePlace += Manager_OnChangePlace;
        }

        private void Manager_OnChangePlace(string obj)
        {
            Inside = false;
        }

        private void LateUpdate()
        {
            UILookToCamera();
        }
        public void Update()
        {
            if (InvokeWithKey && Inside)
            {
                if (Input.GetKeyDown(keyCode))
                {
                    ActionOnEnter.Invoke();
                    //Debug.Log("With Key");
                }
            }
            else if(!Inside)
            {
                DisplayContext_text.text = MarkerContextIdel;
            }
        }

        private void OnTriggerEnter(Collider other)
        {

            InActionBox();
        }
        private void OnTriggerExit(Collider other)
        {
            OutActionBox();
        }


        public void InActionBox()
        {
            Inside = true;
            DisplayContext_text.text = MakerContext + " " + keyCode.ToString();
            if (!InvokeWithKey)
            {


                ActionOnEnter.Invoke();
                //Debug.Log("With OnAction");

            }
        }

        public void OutActionBox()
        {
            Inside = false;
            DisplayContext_text.text = MarkerContextIdel;

            ActionOnExit.Invoke();
            // Debug.Log("With OnAction");

        }

        private void UILookToCamera()
        {
           
            
            var person = FindObjectOfType<PersonController>();
            if (person)
            {
                
                var dis = Vector3.Distance(DisplayContext_text.transform.position, person.transform.position);
                if (dis < 10)
                {
                    if (canvasGroup.alpha < 1)
                        canvasGroup.DOFade(1, 0.1f);

                    var dir = DisplayContext_text.transform.position - person.transform.position;
                    var angel = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
                    DisplayContext_text.transform.DORotate(new Vector3(0, -angel + 90, 0), 0.001f).SetEase(Ease.Linear);
                    markerlogo_billboard.transform.DORotate(new Vector3(0, -angel + 90, 0), 0.001f).SetEase(Ease.Linear);
                    markerline_billboard.transform.DORotate(new Vector3(0, -angel + 90, 0), 0.001f).SetEase(Ease.Linear);
                }
                else
                {
                    if (canvasGroup.alpha > 0)
                        canvasGroup.DOFade(0, 0.1f);
                    
                }
            }
        }
    }
}

