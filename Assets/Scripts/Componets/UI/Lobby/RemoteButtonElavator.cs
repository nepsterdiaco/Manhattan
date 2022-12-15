using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Diaco.Manhatan.UI
{
    public class RemoteButtonElavator : MonoBehaviour
    {
        [SerializeField] private char value;
        private Button Num_button;
        

        private void OnEnable()
        {
            RemoteElavator.instance.OnChangeStutus += Instance_OnChangeStutus;
            Num_button = GetComponent<Button>();
            Num_button.onClick.AddListener(() => {
                RemoteElavator.instance.SetDisplay(value);
            });
        }
        private void OnDisable()
        {
            RemoteElavator.instance.OnChangeStutus -= Instance_OnChangeStutus;
            Num_button.onClick.RemoveAllListeners();
        }
        private void Instance_OnChangeStutus(bool active)
        {
            Num_button.interactable = active;
        }


    }
}
