namespace ShootEmUp
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public class BulletFabrica
    {
        private Transform poolParent;
        private Transform worldTransform;
        private Bullet prefab;
        private readonly Queue<Bullet> m_bulletPool = new();
        private readonly HashSet<Bullet> m_activeBullets = new();
        private Action<Bullet, Collision2D> collisionAction;

        public HashSet<Bullet> ActiveBullets => m_activeBullets;

        public BulletFabrica(Transform poolParent,Transform worldTransform, Bullet prefab, Action<Bullet, Collision2D> collisionAction, int initCount)
        {
            this.collisionAction = collisionAction;
            this.prefab = prefab;
            this.poolParent = poolParent;
            this.worldTransform = worldTransform;
            for (var i = 0; i < initCount; i++)
            {
                Bullet bullet = GameObject.Instantiate(this.prefab, this.poolParent);
                bullet.OnDisableBullet += BackBulletInPool;
                this.m_bulletPool.Enqueue(bullet);
            }
        }

        public Bullet GetBullet(BulletData args) 
        {
            if (this.m_bulletPool.TryDequeue(out var bullet))
            {
                bullet.transform.SetParent(this.worldTransform);
            }
            else
            {
                bullet = GameObject.Instantiate(this.prefab, this.worldTransform);
            }
            
            SetBulletSetting(bullet, args);
            if (this.m_activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += collisionAction;
            }

            return bullet;
        }
        public void BackBulletInPool(Bullet bullet) 
        {
            if (this.m_activeBullets.Remove(bullet))
            {
                bullet.OnCollisionEntered -= collisionAction;
                bullet.transform.SetParent(poolParent);
                this.m_bulletPool.Enqueue(bullet);
                bullet.gameObject.SetActive(false);
            }
        }
        private void SetBulletSetting(Bullet bullet,BulletData args) 
        {
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
