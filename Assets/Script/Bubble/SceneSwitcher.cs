using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bubble
{
    public class SceneSwitcher : MonoBehaviour
    {
        public void GotoPlayScene()
        {

            SceneManager.LoadScene("Game");
        }

        public void GotoTittleScene()
        {
            SceneManager.LoadScene("Tittle");
        }

        
        void Start()
        {

        } 
    
    }
    
}