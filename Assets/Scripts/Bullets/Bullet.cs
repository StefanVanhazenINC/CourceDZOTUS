using System;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour, IPoolable<IMemoryPool>, IDisposable
    {
        public event Action<Bullet> OnDisableBullet;
        [NonSerialized] public bool isPlayer;
        [NonSerialized] public int damage;

        [SerializeField]
        private new Rigidbody2D rigidbody2D;

        [SerializeField]
        private SpriteRenderer spriteRenderer;

        private IMemoryPool pool;
    
        public void Disable() 
        {
            OnDisableBullet?.Invoke(this);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.TryGetComponent(out ICharacterFacade character))
            {
                if (!character.SameTeam(isPlayer))
                {
                    character.TakeDamage(damage);
                    Dispose();
                }
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

        public void Dispose()
        {
            Disable();

            if (pool != null) 
            {
                pool.Despawn(this);
            }
        }
        public void OnDespawned()
        {
            pool = null;
        }
        public void OnSpawned(IMemoryPool pool)
        {
            this.pool = pool;
        }
    }
}