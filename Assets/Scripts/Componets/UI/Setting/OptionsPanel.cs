
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace Diaco.Manhatan.UI
{
    public class OptionsPanel : BaseUIPanel,IPointerExitHandler
    {
        public List<OptionElement> Options;
        public void CloseAllDescriptionsButThis(OptionElement option)
        {
            Options.ForEach(e => {
                if (option != e)
                    e.ShowDescription(false);
            });
        }
        public void CloseAllDescriptions()
        {
            Options.ForEach(e =>
            {
                e.ShowDescription(false);
            });
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            CloseAllDescriptions();
        }
    }


}
