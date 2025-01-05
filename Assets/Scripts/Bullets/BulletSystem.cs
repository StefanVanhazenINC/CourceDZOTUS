using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour
    {
        [SerializeField]
        private int initialCount = 50;
        
        [SerializeField] private Transform poolParent;
        [SerializeField] private Transform worldTransform;

        [SerializeField] private Bullet prefab;
        [SerializeField] private LevelBounds levelBounds;

        private BulletPool bulletPool;
        private BulletFactory bulletFactory;
        private readonly List<Bullet> m_cache = new();
        
        private void Awake()
        {
            InitPoolAndFactory();
        }
        private void InitPoolAndFactory() 
        {
            bulletFactory = new BulletFactory(prefab);
            bulletPool = new BulletPool(poolParent);

            for (int i = 0; i < initialCount; i++)
            {
                Bullet bullet = bulletFactory.CreateBullet(bulletPool.ReturnInPool);
                bulletPool.AddInPool(bullet);
                bullet.Disable();
            }
        }
        private void FixedUpdate()
        {
            CheckInBounds();
        }
        private void CheckInBounds() 
        {
            this.m_cache.Clear();
            this.m_cache.AddRange(bulletPool.ActiveBullets);

            for (int i = 0, count = this.m_cache.Count; i < count; i++)
            {
                var bullet = this.m_cache[i];
                if (!this.levelBounds.InBounds(bullet.transform.position))
                {
                    bullet.Disable();
                }
            }
        }


        public void FlyBulletByArgs(BulletData args)
        {
            Bullet bullet = GetBullet();
            SetBulletSetting(bullet,args);
        }

        private Bullet GetBullet() 
        {
            if (bulletPool.TryGet(out Bullet bullet))
            {
                return bullet;  
            }
            bullet = bulletFactory.CreateBullet(bulletPool.ReturnInPool);
            bulletPool.AddInPool(bullet);
            return bullet;
        }
        private void SetBulletSetting(Bullet bullet, BulletData args)
        {
            bullet.transform.SetParent(worldTransform);
            bullet.gameObject.SetActive(true);
            bullet.SetPosition(args.position);
            bullet.SetColor(args.color);
            bullet.SetPhysicsLayer(args.physicsLayer);
            bullet.damage = args.damage;
            bullet.isPlayer = args.isPlayer;
            bullet.SetVelocity(args.velocity);
        }
      
        
    }
}