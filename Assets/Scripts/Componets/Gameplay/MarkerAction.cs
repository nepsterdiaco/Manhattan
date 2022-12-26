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
        [SerializeField] private string MakerContext;
        [SerializeField] private string MarkerContextIdel;
        [SerializeField] private TextMeshProUGUI DisplayContext_text;
        [SerializeField] private CanvasGroup canvasRotator;
        [SerializeField] private float DurationRotate = 0.01f;
        [SerializeField] private int DelayRotate = 1;
        [SerializeField] private bool InvokeWithKey = false;   
        public bool Inside
        {
            set; 
            get ; 
        }
        [ShowIfGroup("InvokeWithKey")]
        [BoxGroup("InvokeWithKey/Select Input Key")]
        [SerializeField] private KeyCode keyCode;
        [BoxGroup("Action")]
        [SerializeField] private UnityEvent ActionOnEnter;
        [BoxGroup("Action")]
        [SerializeField] private UnityEvent ActionOnExit;

        private Sequence sequence_rotate;
        private int temp_delay = 0;
        private void Start()
        {


            sequence_rotate = DOTween.Sequence();
            Manager.singleton.OnChangePlace += Manager_OnChangePlace;
        }

        private void Manager_OnChangePlace(string obj)
        {
            Inside = false;
        }

        private void LateUpdate()
        {
            if (temp_delay >= DelayRotate)
            {
                UILookToCamera();
                temp_delay = 0;
            }
   
            temp_delay++;

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


            var person = GameObject.FindGameObjectWithTag("Player");
            if (person)
            {
                
                var dis = Vector3.Distance(DisplayContext_text.transform.position, person.transform.position);
                //Debug.Log($"dis:{dis}");
                if (dis < 10)
                {
                    if (canvasRotator.alpha < 1)
                        sequence_rotate.Append(canvasRotator.DOFade(1, 0.1f));

                    var dir = DisplayContext_text.transform.position - person.transform.position;
                    var angel = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
                  sequence_rotate.Append(  canvasRotator.transform.DORotate(new Vector3(0, -angel + 90, 0), DurationRotate)).SetEase(Ease.Linear);
 
                }
                else
                {
                    if (canvasRotator.alpha > 0)
                        sequence_rotate.Append(canvasRotator.DOFade(0, 0.1f));
                    
                }
            }
        }
    }
}

