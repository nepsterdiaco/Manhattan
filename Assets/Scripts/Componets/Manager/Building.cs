using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using Diaco.Manhatan.Structs;
namespace Diaco.Manhatan
{
    public class Building : MonoBehaviour
    {
        public BuildingData info;

        [MinValue(0), MaxValue(7)]
        public float MaxEmissivePower = 3;
        public float SpeedAnimateEmission = 0.5f;
        public Ease ease;
        public LoopType loop;
        public bool Flicker = false;
        [SerializeField]
        [ColorUsage(true,true)]
        private Color emissiveColorStart;
        [SerializeField]
        [ColorUsage(true, true)]
        private Color emissiveColorEnd;
        private new MeshRenderer renderer;
        private Material material;
        //private Manager manager;
      
       [SerializeField] private bool IsFlickering = false;

        
        private void Start()
        {
           
            renderer = GetComponent<MeshRenderer>();
            material = renderer.material;
        }
        private void LateUpdate()
        {
            /*if(Flicker)
            {
                DOFlicker();
            }*/
        }
        private void OnMouseDown()
        {
            Manager.singleton.SelectBuilding(info.Name, this.transform);
        }
        private void OnMouseOver()
        {
            if (Manager.singleton.BuildingOwner(info.Name))
                DOFlicker();
        }
        public void ActiveFlicker()
        {
            Flicker = true;
          //  Debug.Log("AAAA");
        }
        public void DOFlicker()
        {
            if (IsFlickering == false)
            {
                IsFlickering = true;

               material.DOColor(emissiveColorEnd, SpeedAnimateEmission).OnComplete(() => {

                    material.DOColor(emissiveColorStart, SpeedAnimateEmission).OnComplete(() => { IsFlickering = false; });

                });

            }
           
        }
    }
}
