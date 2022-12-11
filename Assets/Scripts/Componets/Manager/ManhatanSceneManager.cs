using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Diaco.Manhatan.Managers
{
    public class ManhatanSceneManager : MonoBehaviour
    {

        public void Start()
        {
            LoadScene(1);
        }
        public void LoadScene(int id)
        {
            // FadeIn();
            StartCoroutine(loadscene(id));

        }
        private IEnumerator loadscene(int id)
        {
            
           
            var c = SceneManager.LoadSceneAsync(id);
             //
           
            while (c.progress < 1)
            {
                /// _progressBar.fillAmount = gameLevel.progress;
                Debug.Log("OMID" + c.progress);
                yield return null;
            }
        }
    }
}
