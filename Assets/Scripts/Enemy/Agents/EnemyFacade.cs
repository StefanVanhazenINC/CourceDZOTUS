namespace ShootEmUp
{
    using System;
    using UnityEngine;
    using Zenject;

    public class EnemyFacade : MonoBehaviour, ICharacterFacade, IPoolable<IMemoryPool>, IDisposable
    {
        [Inject]
        [SerializeField] private EnemyAttackAgent enemyAttack;

        [Inject]
        [SerializeField] private EnemyMoveAgent enemyMove;

        [Inject]
        [SerializeField] private HitPointsComponent hitPointsComponent;

        [Inject]
        [SerializeField] private TeamComponent teamComponent;
        public event Action<EnemyFacade> disableAction;


        private IMemoryPool _pool;

        private void OnDisable()
        {
            disableAction = delegate { };
        }
        public void SetTarget(PlayerFacade target) 
        {
            enemyAttack.SetTarget(target);
        }

        public void SetDestination(Vector2 endPoint) 
        {
            enemyMove.SetDestination(endPoint);
        }
        public void Disable() 
        {
            disableAction?.Invoke(this);
        }
        public void AddActionHpEmpty() 
        {
            hitPointsComponent.hpEmpty += (gameObject) => Dispose();
        }
        public void RemoveActionHpEmpty() 
        {
            hitPointsComponent.hpEmpty -= (gameObject) => Dispose();
        }

        public bool SameTeam(bool isPlayer)
        {
            bool sameTeam = teamComponent.IsPlayer == isPlayer ? true : false;
            return sameTeam;
        }

        public void TakeDamage(int value)
        {
            hitPointsComponent.TakeDamage(value);   
        }


        public void OnDespawned()
        {
            _pool = null;
        }
        public void OnSpawned(IMemoryPool pool)
        {
            AddActionHpEmpty();
            _pool = pool;
        }
        public void Dispose()
        {
            RemoveActionHpEmpty();
            Disable();
            if (_pool != null) 
            {
                _pool.Despawn(this);
            }
        }
    }
}