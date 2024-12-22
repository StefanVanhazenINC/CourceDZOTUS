using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour
    {
        [SerializeField]
        private int initialCount = 50;
        
        [SerializeField] private Transform container;
        [SerializeField] private Bullet prefab;
        [SerializeField] private Transform worldTransform;
        [SerializeField] private LevelBounds levelBounds;

        private BulletFabrica bulletFabrica;
        private readonly Queue<Bullet> m_bulletPool = new();
        private readonly HashSet<Bullet> m_activeBullets = new();
        private readonly List<Bullet> m_cache = new();
        
        private void Awake()
        {
        
            bulletFabrica = new BulletFabrica(container, worldTransform, prefab, OnBulletCollision, initialCount);
        }
        
        //=========================
        private void FixedUpdate()
        {
            CheckInBounds();
        }
        private void CheckInBounds() 
        {
            this.m_cache.Clear();
            this.m_cache.AddRange(bulletFabrica.ActiveBullets);

            for (int i = 0, count = this.m_cache.Count; i < count; i++)
            {
                var bullet = this.m_cache[i];
                if (!this.levelBounds.InBounds(bullet.transform.position))
                {
                    bullet.Disable();
                }
            }
        }
        //==============================
        public void FlyBulletByArgs(BulletData args)
        {
            Bullet bullet = bulletFabrica.GetBullet(args);
        }
        
        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            BulletUtils.DealDamage(bullet, collision.gameObject);
            bullet.Disable();
            
        }
        
    }
}