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

        [MinValue(0), MaxValue(50)]
        public float EmissivePower = 50;
        public float SpeedAnimateEmission = 1f;
        public Ease ease;
        public LoopType loop;
       /* public bool Flicker = false;
        [SerializeField]
        [ColorUsage(true,true)]
        private Color emissiveColorStart;
        [SerializeField]
        [ColorUsage(true, true)]
        private Color emissiveColorEnd;*/
        private new MeshRenderer renderer;
        private Material material;
        //private Manager manager;
      
       [SerializeField] private bool IsFlickering = false;

        
        private void Start()
        {
           // var buildingmanager = FindObjectOfType<BuildingManager>();

            renderer = GetComponent<MeshRenderer>();
            material = renderer.material;
            BuildingManager.AddBuilding(this);
        }

        private void OnMouseDown()
        {
            Manager.singleton.SelectBuilding(info.Name, this.transform, info);
        }
        private void OnMouseOver()
        {
           if (Manager.singleton.BuildingOwner(info.Name))
                DOFlicker();
        }
        private void OnMouseExit()
        {
            IsFlickering = false;
        }


        [Button("aaa")]
        public void DOFlicker()
        {
            
            if (IsFlickering == false)
            {
                IsFlickering = true;
                DOVirtual.Float(0, EmissivePower, SpeedAnimateEmission, (x) =>
                {
                    material.SetFloat("_PowerEmissive", x);
                }).OnComplete(() =>
                {
                    DOVirtual.Float(EmissivePower, 0, SpeedAnimateEmission, (x) =>
                    {
                        material.SetFloat("_PowerEmissive", x);
                       
                    });
                }
                ).SetEase(ease);

            }
           
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;

            Gizmos.DrawSphere(transform.position, 5f);
        }
    }
}
