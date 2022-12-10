
using System.Collections.Generic;

using UnityEngine;

namespace Diaco.Manhatan.UI
{
    public class TabController : MonoBehaviour
    {
       // [SerializeField] private Button Left_Button;
       // [SerializeField] private Button Right_Button;
        [SerializeField] private List<TabButton> Tabs;

        public static TabController instance;
        private int currentTabIndex = 0;
        public void Awake()
        {
            if (instance == null)
                instance = this;
        }
        public void OnEnable()
        {
            if (instance == null)
                instance = this;

          //  Left_Button.onClick.AddListener(GoToLeftTab);
           // Right_Button.onClick.AddListener(GoToRightTab);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
                GoToRightTab();
            if (Input.GetKeyDown(KeyCode.Q))
                GoToLeftTab();
        }
        public void OnDisable()
        {
          //  Left_Button.onClick.RemoveAllListeners();
          //  Right_Button.onClick.RemoveAllListeners();
        }
        public void HoldActiveThisTab( TabButton tab)
       {
           Tabs.ForEach((element) =>
           {
               if (element != tab)
               {
                   element.ActiveStatusTab(false);
               }
           });
       }
        public void CloseAllTab()
        {
            Tabs.ForEach((element) =>
            {
                element.OpenOptionsTab(false);
            });
        }
        private void MoveInTabWithButton(int c)
        {
            currentTabIndex = Mathf.Clamp(c, 0, Tabs.Count - 1);
            HoldActiveThisTab(Tabs[currentTabIndex]);
            Tabs[currentTabIndex].ActiveStatusTab(true);
            Tabs[currentTabIndex].OpenOptionsTab(true);
        }
        private void GoToLeftTab()
        {
            CloseAllTab();

            var c = currentTabIndex - 1;
            MoveInTabWithButton(c);
            //Debug.Log($"Q:{currentTabIndex}" + Tabs[currentTabIndex].name);
        }
        private void GoToRightTab()
        {
            CloseAllTab();
            var c = currentTabIndex + 1;
            MoveInTabWithButton(c); 
           // Debug.Log($"E{currentTabIndex}:" + Tabs[currentTabIndex].name);
        }
       
    }
}