using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bubble
{
    [CreateAssetMenu (menuName = "Generator/Player/Create Side")]
    public class Side : ScriptableObject
    {
        [Header("Side")]
        public char sidename;
        public Sprite Icon;
        public play gamer;

        public Sprite getImg()
        {
            return Icon;
        }
        
        public bool SetVal(GameObject GridSpaceButton)
        {
            if (GridSpaceButton)
            {
                GridSpace GS = GridSpaceButton.GetComponent<GridSpace>();
                GS.symbol = this.sidename;
                if (GS.image)
                {
                    GS.image.sprite = this.Icon;
                }
                return true;
            }
            else 
            {
                return false;
            }
        }

        public void GetPlayer(PlayerScript Player)
        {
            play temp = new play(Player, null); 
            gamer = temp;
        }

        public void GetAI(AI comp)
        {
            play temp = new play(null, comp); 
            gamer = temp;
        }

        public void Resetgamer()
        {
            play temp = new play(null, null);
            gamer = temp;
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
