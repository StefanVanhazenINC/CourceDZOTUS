using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {
        [SerializeField] private WeaponComponent weaponComponent;
        [SerializeField] private TeamComponent teamComponent;
        [SerializeField] private EnemyMoveAgent moveAgent;
        [SerializeField] private float countdown;

        private GameObject target;
        private HitPointsComponent hitPointsTarget;
        private float currentTime;

        public WeaponComponent WeaponComponent { get => weaponComponent; }

        public void SetTarget(GameObject target)
        {
            this.target = target;
            hitPointsTarget = this.target.GetComponent<HitPointsComponent>();
            this.currentTime = this.countdown;
        }
  
        private void FixedUpdate()
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

        private void Fire()
        {
            weaponComponent.OnFire(teamComponent.IsPlayer);
        }
    }
}