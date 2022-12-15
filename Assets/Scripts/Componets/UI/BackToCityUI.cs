using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diaco.Manhatan.UI
{
    public class BackToCityUI :BaseUIPanel 
    {
        public BaseUIPanel NextMenu;


        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                this.gameObject.SetActive(false);
                NextMenu.gameObject.SetActive(true);
            }
        }
    }
}
