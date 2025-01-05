namespace ShootEmUp
{
    using System;
    using UnityEngine;

    public class EnemyFacade : MonoBehaviour
    {
        [SerializeField] private EnemyAttackAgent enemyAttack; 
        [SerializeField] private EnemyMoveAgent enemyMove;
        [SerializeField] private HitPointsComponent hitPointsComponent;

        private Action<EnemyFacade> disableAction;
        public void SetTarget(GameObject target) 
        {
            enemyAttack.SetTarget(target);
        }

        public void SetDestination(Vector2 endPoint) 
        {
            enemyMove.SetDestination(endPoint);
        }
        public void SetBulletSystem(BulletSystem bulletSystem) 
        {
            enemyAttack.WeaponComponent.SetBulletSystem(bulletSystem);  
        }
        public void Disable() 
        {
            disableAction?.Invoke(this);

        }
        public void AddActionHpEmpty(Action<EnemyFacade> action) 
        {
            disableAction = action;
            hitPointsComponent.hpEmpty += (gameObject) => Disable();
        }
        public void RemoveActionHpEmpty() 
        {
            hitPointsComponent.hpEmpty -= (gameObject) => Disable();
            disableAction = delegate { };
        }
    }
}