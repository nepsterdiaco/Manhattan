using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diaco.Manhatan
{
    public class RoomSpawner : MonoBehaviour
    {

        public void Start()
        {
            Manager.singleton.LoadRoom();
        }
    }
}