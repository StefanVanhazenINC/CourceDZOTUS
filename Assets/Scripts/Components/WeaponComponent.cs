using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class WeaponComponent 
    {
        private BulletConfig bulletConfig;
        private Transform firePoint;

        [Inject]
        private BulletSystem bulletSystem;

        public WeaponComponent(BulletConfig bulletConfig, Transform firePoint)
        {
            this.bulletConfig = bulletConfig;
            this.firePoint = firePoint;
        }

        public Vector2 Position
        {
            get { return this.firePoint.position; }
        }

        public Quaternion Rotation
        {
            get { return this.firePoint.rotation; }
        }
    
        public void OnFire(bool isPlayer) 
        {
            bulletSystem.FlyBulletByArgs(new BulletData
            {
                isPlayer = isPlayer,
                physicsLayer = (int)this.bulletConfig.physicsLayer,
                color = this.bulletConfig.color,
                damage = this.bulletConfig.damage,
                position = Position,
                velocity = Rotation * Vector3.up * this.bulletConfig.speed
            });
        }
        
    }
}