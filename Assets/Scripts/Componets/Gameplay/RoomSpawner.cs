using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace Diaco.Manhatan
{
    public class RoomSpawner : MonoBehaviour
    {
        [SerializeField] private StarterAssets.ThirdPersonController Person;
        [SerializeField] private Cinemachine.CinemachineVirtualCamera virtualCamera;
        [SerializeField] private Camera MainCamera;
        public void Start()
        {
            Manager.singleton.LoadRoom();
            
        }

        public void ActivePlayer()
        {
            MainCamera.gameObject.SetActive(true);
            virtualCamera.gameObject.SetActive(true);
            Person.transform.parent.gameObject.SetActive(true);
            
        }
    }
}