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
            Num_button = GetComponent<Button>();
            Num_button.onClick.AddListener(() => {
                RemoteElavator.instance.SetDisplay(value);
            });
        }
        private void OnDisable()
        {
            Num_button.onClick.RemoveAllListeners();
        }
    }
}
