using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;


[SelectionBase]
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

    [Header("Editor Utility")] public string StringToOmit;
    [SerializeField] private bool DoTransformWithRenaming;
    [Button]
    public void GetNameFromChildren()
    {
        if (DoTransformWithRenaming) SetTransformToZero();
        var child = gameObject.GetComponentsInChildren<Transform>()[1];
        var mName = child.name;
        if (StringToOmit.Length > 0)
        {
            var s = mName.Replace(StringToOmit, "");        
            transform.name = s;
            return;
        }
        transform.name = mName;
    }

    public void SetTransformToZero()
    {
        var child = gameObject.GetComponentsInChildren<Transform>()[1];
        child.position = new Vector3(0, 0, 0);
        child.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        // child.localScale = new Vector3(1, 1, 1);
    }
}
