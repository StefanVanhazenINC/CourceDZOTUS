namespace ShootEmUp
{
    using System;
    using UnityEngine;

    public class EnemyFacad : MonoBehaviour
    {
        [SerializeField] private EnemyAttackAgent enemyAttack; 
        [SerializeField] private EnemyMoveAgent enemyMove;
        [SerializeField] private HitPointsComponent hitPointsComponent;

       
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
        public void AddActionHpEmpty(Action<GameObject> action) 
        {
            hitPointsComponent.hpEmpty += action;
        }
       
    }
}