
using UnityEngine;
using UnityEngine.UI;
namespace Diaco.Manhatan.UI
{
    public class AskQuitPanel : BaseUIPanel
    {
        [SerializeField] private Ask ask;
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
            if (ask == Ask.AppQuit)
                Manager.singleton.ExitApp();
            else if (ask == Ask.BackToCity)
                Manager.singleton.LoadScene(1);
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
