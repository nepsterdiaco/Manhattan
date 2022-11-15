using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Diaco.Manhatan;
public class TriggerLockToNumPad : MonoBehaviour
{
    public bool Active = false;

   // private Manager manager;
    private void Start()
    {
       //manager =  FindObjectOfType<Manager>();
    }
    public void OnTriggerEnter(Collider other)
    {
        
        Active = true;
    }
    public void OnTriggerExit(Collider other)
    {
        Active = false;
    }
}
