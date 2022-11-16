using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyThisObject : MonoBehaviour
{
    private void Awake()
    {
        GameObject.DontDestroyOnLoad(gameObject);
    }
}
