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
        [SerializeField] private CanvasGroup BuildingMarker;
        [MinValue(0), MaxValue(50)]
        [SerializeField] private float EmissivePower = 50;
        [SerializeField] private float SpeedAnimateEmission = 1f;
        [SerializeField] private Ease ease;
        [SerializeField] private LoopType loop;
        [SerializeField] private bool IsFlickering = false;
        [SerializeField] private bool IsEnabledBuildigMarker = false;
        private new MeshRenderer renderer;
        private Material material;
        
      
       

        
        private void Start()
        {
           // var buildingmanager = FindObjectOfType<BuildingManager>();

            renderer = GetComponent<MeshRenderer>();
            material = renderer.material;
            BuildingManager.AddBuilding(this);
        }
        private void LateUpdate()
        {
            UILookToCamera();
        }
        private void OnMouseDown()
        {
            Manager.singleton.UserSelectedBuilding(info.Name, this.transform, info);
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
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;

            Gizmos.DrawSphere(transform.position, 5f);
        }

        [Button("TestFlicker")]
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
        [Button("EnabelBuildingMarker")]
        public void EnableBuildingMarker()
        {
            if(!IsEnabledBuildigMarker)
            {

                BuildingMarker.DOFade(1, 0.5f);
                IsEnabledBuildigMarker = true;
            }
        }
        private void UILookToCamera()
        {


            var camera = FindObjectOfType<Camera>();
            if (camera)
            {
                var dir = BuildingMarker.transform.position - camera.transform.position;
                var angel = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
                BuildingMarker.transform.DORotate(new Vector3(0, -angel + 90, 0), 0.001f).SetEase(Ease.Linear);
            }
        }
    }
}
