using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class HitPointsComponent 
    {
        public GameObject character;
        public event Action<GameObject> hpEmpty;
        
        private int hitPoints;

        public HitPointsComponent(GameObject character, int hitPoints)
        {
            this.character = character;
            this.hitPoints = hitPoints;
        }

        public bool IsHitPointsExists() 
        {
            return this.hitPoints > 0;
        }

        public void TakeDamage(int damage)
        {
            this.hitPoints -= damage;
            if (this.hitPoints <= 0)
            {
                this.hpEmpty?.Invoke(character);
            }
        }
    }
}