using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class BulletSystem : IFixedTickable
    {
        [Inject]
        private LevelBounds levelBounds;
        [Inject]
        private BulletFactory bulletFactory;

        private readonly List<Bullet> m_cache = new();

        public void FixedTick()
        {
            CheckInBounds();
        }
       
        private void CheckInBounds() 
        {
            
            int cacheCount = m_cache.Count;
            for (int i = 0, count = cacheCount; i < count; i++)
            {
                if (this.m_cache.Count >= cacheCount) 
                {
                    var bullet = this.m_cache[i];
                    if (!this.levelBounds.InBounds(bullet.transform.position))
                    {
                        bullet.Dispose();
                    }
                }
            }
        }


        public void FlyBulletByArgs(BulletData args)
        {
            Bullet bullet = bulletFactory.Create() ;
            AddCacheBullet(bullet);
            SetBulletSetting(bullet,args);
        }
        public void AddCacheBullet(Bullet bullet) 
        {
            this.m_cache.Add(bullet);
        }
        public void RemoveCacheBullet(Bullet bullet)
        {
            bullet.OnDisableBullet -= RemoveCacheBullet;
            this.m_cache.Remove(bullet);
        }
      
        private void SetBulletSetting(Bullet bullet, BulletData args)
        {
            bullet.gameObject.SetActive(true);
            bullet.SetPosition(args.position);
            bullet.SetColor(args.color);
            bullet.SetPhysicsLayer(args.physicsLayer);
            bullet.damage = args.damage;
            bullet.isPlayer = args.isPlayer;
            bullet.SetVelocity(args.velocity);
            bullet.OnDisableBullet += RemoveCacheBullet;
        }

    }
}