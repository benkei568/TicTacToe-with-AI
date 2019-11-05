using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Bubble
{
    public class ChooseSide : MonoBehaviour
    {
        public Side sidex;
        public Side sideo;
        public PlayerScript Player;
        public AI comp;
        public SceneSwitcher Scene;


        public void chooseX()
        {
            sidex.GetPlayer(Player);
            sideo.GetAI(comp);
            Scene.GotoPlayScene();
        }

        public void chooseO()
        {
            sideo.GetPlayer(Player);
            sidex.GetAI(comp);
            Scene.GotoPlayScene();
        }

        public void QuitGame()
        {
            Application.Quit();
            Debug.Log("Game is exiting");
        }
        // Start is called before the first frame update
        void Start()
        {
            sidex.Resetgamer();
            sideo.Resetgamer();
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
    
}
