using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bubble
{
    [System.Serializable]
    public class play
    {
        public PlayerScript Player;
        public AI Comp;

        public play(PlayerScript player, AI computer)
        {
            this.Player = null;
            this.Comp = null;
            if (player != null)
            {
                this.Player = player;
            }
            if (computer != null)
            {
                this.Comp = computer;
            }
        }

    }

    
}
