
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Diaco.Manhatan.UI
{
    public class Setting_UI : BaseUIPanel
    {
        
        [SerializeField] private BaseUIPanel BackMenu;
        private void Update()
        {


            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Back();
            }

        }
        private void Back()
        {
            if (!BackMenu.gameObject.activeSelf)
            {
                this.gameObject.SetActive(false);
                BackMenu.gameObject.SetActive(true);
            }
        }
    }
}