namespace ShootEmUp
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public class BulletFactory
    {
        private Bullet prefab;
        public BulletFactory(Bullet prefab)
        {
            this.prefab = prefab;
        }

        public Bullet CreateBullet(Action<Bullet> disableAction) 
        {
            Bullet bullet = GameObject.Instantiate(this.prefab);
            bullet.gameObject.SetActive(false);
            bullet.OnDisableBullet += disableAction;
            return bullet;
        }
     

       
    }
}
