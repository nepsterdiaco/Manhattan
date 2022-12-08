using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diaco.Manhatan.UI.Tab
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
