using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Diaco.Manhatan;
public class HUD : MonoBehaviour
{


    public Button Reset_button;
    public TextMeshProUGUI LOG_text;
    
    void Start()
    {
        if (Manager.singleton == null)
        {
            
            Reset_button.onClick.AddListener(() =>
            {

                Manager.singleton.ResetWorld();

            });
        }
    }

    private void OnEnable()
    {
        if (Manager.singleton == null)
        {
           
            Reset_button.onClick.AddListener(() =>
            {

                Manager.singleton.ResetWorld();

            });
        }
    }
    public void HUD_LOG(string log)
    {
        LOG_text.text = log;
    }
}
