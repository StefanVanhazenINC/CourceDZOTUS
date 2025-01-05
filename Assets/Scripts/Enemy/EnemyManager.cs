using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private int _enemyCount = 7;
        [SerializeField] private GameObject character;
        [SerializeField] private EnemyPositions enemyPositions;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private EnemyFacade prefabEnemy;
        [SerializeField] private Transform poolParent;
        [SerializeField] private Transform worldTransform;
        private EnemyFactory enemyFactory;
        private EnemyPool enemyPool;

        private void Awake()
        {
            InitPoolAndFactory();
        }
        private void InitPoolAndFactory()
        {
            enemyFactory = new EnemyFactory(prefabEnemy);
            enemyPool = new EnemyPool(poolParent);

            for (int i = 0; i < _enemyCount; i++)
            {
                EnemyFacade enemy = enemyFactory.CreateEnemy(_bulletSystem,enemyPool.ReturnInPool);
                enemyPool.AddInPool(enemy);
                enemy.Disable();
            }
        }
        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);

                if (enemyPool.ActiveEnemies.Count < _enemyCount) 
                {
                    EnemyFacade enemy = GetEnemy();
                    SetEnemySetting(enemy,this.enemyPositions.RandomSpawnPosition(), this.enemyPositions.RandomAttackPosition());
                }
            }
        }

        private EnemyFacade GetEnemy() 
        {
            if (enemyPool.TryGet(out EnemyFacade enemy))
            {
                return enemy;
            }
            enemy = enemyFactory.CreateEnemy(_bulletSystem, enemyPool.ReturnInPool);
            enemyPool.AddInPool(enemy);
            return enemy;
        }
        private void SetEnemySetting(EnemyFacade enemy, Transform spawnPosition, Transform attackPosition) 
        {
            enemy.SetTarget(character);
            enemy.gameObject.SetActive(true);
            enemy.transform.position = spawnPosition.position;
            enemy.SetDestination(attackPosition.position);
            enemy.transform.SetParent(worldTransform);
        }

    }
}