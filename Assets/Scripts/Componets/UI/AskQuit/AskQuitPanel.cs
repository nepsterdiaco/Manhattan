
using UnityEngine;
using UnityEngine.UI;
namespace Diaco.Manhatan.UI
{
    public class AskQuitPanel : BaseUIPanel
    {
       
        [SerializeField] private BaseUIPanel BackMenu;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Yes();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cancel();
            }
 

        }
        private void Yes()
        {
            Manager.singleton.ExitApp();
        }
        private void Cancel()
        {
            if (!BackMenu.gameObject.activeSelf)
            {
                this.gameObject.SetActive(false);
                BackMenu.gameObject.SetActive(true);
            }
        }


    }
}
