using UnityEngine;

namespace ShootEmUp
{
    public sealed class TeamComponent 
    {
        private bool isPlayer;
        public bool IsPlayer
        {
            get { return this.isPlayer; }
        }
        
        public TeamComponent(bool isPlayer)
        {
            this.isPlayer = isPlayer;
        }
    }
}