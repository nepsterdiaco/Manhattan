using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Diaco.misc
{


    public class SlideTextValue : MonoBehaviour
    {
        public float omid ;
        [SerializeField] private Button Left_button;
        [SerializeField] private Button Right_button;
        [SerializeField] private TextMeshProUGUI Contextviwer_text;
        [SerializeField] private string[] Contexts;
        private int currentIndex = 0;

        void Start()
        {

        }

        private void OnEnable()
        {
            Left_button.onClick.AddListener(() => { ChangeContext(-1); });
            Right_button.onClick.AddListener(() => { ChangeContext(+1); });
        }

        private void OnDisable()
        {
            Left_button.onClick.RemoveAllListeners();
            Right_button.onClick.RemoveAllListeners();
        }

        private void ChangeContext(int dir)
        {

            if (dir == -1) // left
            {
                int d = currentIndex - 1;
                if (d >= 0 && d < Contexts.Length)
                {
                    Contextviwer_text.text = Contexts[d];
                    currentIndex = d;
                    ///    Debug.Log("Move Left" + currentIndex);
                }
                else
                {
                    Contextviwer_text.text = Contexts[Contexts.Length - 1];
                    currentIndex = Contexts.Length - 1;
                }
            }
            else // right
            {
                int d = currentIndex + 1;
                if (d >= 0 && d < Contexts.Length)
                {
                    Contextviwer_text.text = Contexts[d];
                    currentIndex = d;
                    ///       Debug.Log("Move Left" + currentIndex);
                }
                else
                {
                    Contextviwer_text.text = Contexts[0];
                    currentIndex = 0;
                }
            }
        }

    }
}