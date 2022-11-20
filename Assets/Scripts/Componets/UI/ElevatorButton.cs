using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;
namespace Diaco.Manhatan
{
    public class ElevatorButton : MonoBehaviour
    {
        private Elavator elavator;

        private Button btn;
        private void Start()
        {
            if (elavator == null)
                elavator = FindObjectOfType<Elavator>();
            if (btn == null)
                btn = GetComponent<Button>();
            btn.onClick.AddListener(() => {

                var context = btn.GetComponentInChildren<TextMeshProUGUI>().text;
                elavator.SetDisplay(context);
            });
        }

    }
}