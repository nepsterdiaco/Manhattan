using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
namespace Diaco.Manhatan
{
    public class MarkerBox : MonoBehaviour
    {
        
        public MarkerAction Target;


        private void Start()
        {
            Target = GetComponentInParent<MarkerAction>();
        }
        private void OnTriggerEnter(Collider other)
        {
           
            Target.InActionBox();
        }
        private void OnTriggerExit(Collider other)
        {
            Target.OutActionBox();
        }
    } 
}