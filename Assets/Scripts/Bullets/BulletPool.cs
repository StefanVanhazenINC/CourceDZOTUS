namespace ShootEmUp
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Pool;

    public class BulletPool 
    {
        private Transform poolParent;

        private readonly Queue<Bullet> m_bulletPool = new();
        private readonly HashSet<Bullet> m_activeBullets = new();

        public HashSet<Bullet> ActiveBullets => m_activeBullets;

        public BulletPool(Transform poolParent)
        {
            this.poolParent = poolParent;
        }


        public bool TryGet(out Bullet bullet) 
        {
            if (this.m_bulletPool.Count > 0)
            {
                this.m_bulletPool.TryDequeue(out bullet);
                m_activeBullets.Add(bullet);
                return true;
            }
            bullet = null;
            return false;
        }

        public void AddInPool(Bullet bullet) 
        {
            m_activeBullets.Add(bullet);
        }
        public void ReturnInPool(Bullet bullet)
        {
            if (this.m_activeBullets.Remove(bullet))
            {
                bullet.transform.SetParent(poolParent);
                this.m_bulletPool.Enqueue(bullet);
                bullet.gameObject.SetActive(false);
            }
        }

       
    }
}