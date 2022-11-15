using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AttachCamToWorldUI : MonoBehaviour
{
    private Canvas canvas;
    void Start()
    {
        canvas = GetComponent<Canvas>();

    }
    private void LateUpdate()
    {
        if (!canvas.worldCamera && FindObjectOfType<PersonController>())
        {
            var cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            canvas.worldCamera = cam;
        }
    }
    // Update is called once per frame

}
