using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Bubble
{
    public class GridSpace : MonoBehaviour
    {
        Side side;
        public char symbol;
        public Image image;
        public Game main;
        public BoardController board;
        public int x;
        public int y;


        public void OnClick()
        {
            side = main.whichside();
            if(side.SetVal(this.gameObject))
            {
                TurnOffSkillIcon(this.gameObject);
                board.Choose(x, y, symbol);
            }
        }

        public void AIClick()
        {
            side = main.whichside();
            if(side.SetVal(this.gameObject))
            {
                TurnOffSkillIcon(this.gameObject);
                board.AIChoose(x, y, symbol);
            }
        }

        public int getpos()
        {
            return (x*3)+y;
        }

        public void TurnOnSkillIcon(GameObject SkillDisplayObject)
        {
            SkillDisplayObject.GetComponent<Button>().interactable = true;
        }

        //Turn off the Skill  so it cannot be use = stop it from being clickable and enable the UI elements that make it change colour
        public void TurnOffSkillIcon(GameObject SkillDisplayObject)
        {
            SkillDisplayObject.GetComponent<Button>().interactable = false;
        }


        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
    
}
