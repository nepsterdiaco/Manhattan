
using UnityEngine;

namespace Diaco.Manhatan.UI
{
    public class DescriptionElement : MonoBehaviour
    {
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.E)|| Input.GetKeyDown(KeyCode.Q))
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
