using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet> OnDisableBullet;
        [NonSerialized] public bool isPlayer;
        [NonSerialized] public int damage;

        [SerializeField]
        private new Rigidbody2D rigidbody2D;

        [SerializeField]
        private SpriteRenderer spriteRenderer;

    
        public void Disable() 
        {
            OnDisableBullet?.Invoke(this);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.collider.TryGetComponent(out TeamComponent team))
            {
                return;
            }

            if (isPlayer == team.IsPlayer)
            {
                return;
            }

            if (collision.collider.TryGetComponent(out HitPointsComponent hitPoints))
            {
                hitPoints.TakeDamage(damage);
                Disable();
            }

        }

       
        public void SetVelocity(Vector2 velocity)
        {
            this.rigidbody2D.velocity = velocity;
        }

        public void SetPhysicsLayer(int physicsLayer)
        {
            this.gameObject.layer = physicsLayer;
        }

        public void SetPosition(Vector3 position)
        {
            this.transform.position = position;
        }

        public void SetColor(Color color)
        {
            this.spriteRenderer.color = color;
        }

        
    }
}