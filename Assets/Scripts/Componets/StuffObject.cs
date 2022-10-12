using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StuffObject : MonoBehaviour
{
    public Diaco.Manhatan.Structs.Stuff Data;

    public String GetName()
    {
        return Data.name;
    } 
    public String GetGroup()
    {
        return Data.group;
    } 
}
