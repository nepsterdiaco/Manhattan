
using UnityEngine.EventSystems;
using UnityEngine;

namespace Diaco.Manhatan.UI
{
    public class OptionElement : BaseUIPanel,IPointerEnterHandler,IPointerExitHandler
    {
        public GameObject Description;
        
        [SerializeField]private OptionsPanel optionsPanel;

        public void OnPointerEnter(PointerEventData eventData)
        {
            optionsPanel.CloseAllDescriptionsButThis(this);
            ShowDescription(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
           // ShowDescription(false);
        }

        public void ShowDescription(bool show)
        {
            Description.SetActive(show);
        }
    }
}
