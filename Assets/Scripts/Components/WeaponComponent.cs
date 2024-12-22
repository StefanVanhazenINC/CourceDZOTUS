using UnityEngine;

namespace ShootEmUp
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        [SerializeField] private BulletConfig bulletConfig;
        [SerializeField] private Transform firePoint;
        private BulletSystem bulletSystem;
        public Vector2 Position
        {
            get { return this.firePoint.position; }
        }

        public Quaternion Rotation
        {
            get { return this.firePoint.rotation; }
        }
        public void SetBulletSystem(BulletSystem bulletSystem) 
        {
            this.bulletSystem = bulletSystem;   
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