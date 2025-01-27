using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : IFixedTickable
    {
        [Inject]
        [SerializeField] private WeaponComponent weaponComponent;
        [Inject]
        [SerializeField] private TeamComponent teamComponent;
        [Inject]
        [SerializeField] private EnemyMoveAgent moveAgent;
        [SerializeField] private float countdown;

        private PlayerFacade target;
        private HitPointsComponent hitPointsTarget;
        private float currentTime;

        public EnemyAttackAgent( float countdown)
        {
            this.countdown = countdown;
        }

        public WeaponComponent WeaponComponent { get => weaponComponent; }

        public void SetTarget(PlayerFacade target)
        {
            this.target = target;
            hitPointsTarget = this.target.HitPointsComponent;
            this.currentTime = this.countdown;
        }
  
        

        private void Fire()
        {
            weaponComponent.OnFire(teamComponent.IsPlayer);
        }

        public void FixedTick()
        {
            if (!this.moveAgent.IsReached)
            {
                return;
            }

            if (!hitPointsTarget.IsHitPointsExists())
            {
                return;
            }

            this.currentTime -= Time.fixedDeltaTime;
            if (this.currentTime <= 0)
            {
                this.Fire();
                this.currentTime += this.countdown;
            }
        }
    }
}