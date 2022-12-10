
using UnityEngine;
using UnityEngine.UI;
namespace Diaco.Manhatan.UI
{
    public class AskQuitPanel : MonoBehaviour
    {
        [SerializeField] private Button Yes_Button;
        [SerializeField] private Button Quit_Button;


        private void OnEnable()
        {
            Yes_Button.onClick.AddListener(Yes);
            Quit_Button.onClick.AddListener(Quit);
        }
        private void OnDisable()
        {
            Yes_Button.onClick.RemoveAllListeners();
            Quit_Button.onClick.RemoveAllListeners();
        }
        private void Yes()
        {

        }
        private void Quit()
        {

        }
    }
}
