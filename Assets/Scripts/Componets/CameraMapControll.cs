using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
[Obsolete]
public class CameraMapControll : MonoBehaviour
{
    public Transform Building;
    public float Duration = 1;

    [Button("GO TO Building")]
    
    public void GotoBuilding()
    {
        transform.DOMove(Building.transform.position, Duration);
    }

}
