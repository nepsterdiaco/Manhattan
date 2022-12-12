using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace Diaco.Manhatan.UI
{
   public  class UnitData : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI unit_text;

        public void Set( int unit)
        {
            this.unit_text.text = unit.ToString();
        }
    }
}
