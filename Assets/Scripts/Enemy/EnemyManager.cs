using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemyManager 
    {
        private int enemyCount = 7;
        private MonoBehaviour context;
        [Inject]
        private EnemyPositions enemyPositions;
        [Inject]
        private PlayerFacade character;
        [Inject]
        private EnemyFactory enemyFactory;

        private int _countActiveEnemy = 0;

        public EnemyManager(int enemyCount, MonoBehaviour context)
        {
            this.enemyCount = enemyCount;
            
            this.context = context;
            this.context.StartCoroutine(Start());
        }

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);

                if (_countActiveEnemy < enemyCount)
                {
                    EnemyFacade enemy = enemyFactory.Create() ;
                    _countActiveEnemy++;
                    SetEnemySetting(enemy, this.enemyPositions.RandomSpawnPosition(), this.enemyPositions.RandomAttackPosition());
                }
            }
        }
        private void DisableEnemy(EnemyFacade enemy) 
        {
            _countActiveEnemy--;
            enemy.disableAction -= DisableEnemy;
        }
        private void SetEnemySetting(EnemyFacade enemy, Transform spawnPosition, Transform attackPosition)
        {
            enemy.SetTarget(character);
            enemy.gameObject.SetActive(true);
            enemy.transform.position = spawnPosition.position;
            enemy.SetDestination(attackPosition.position);
            enemy.disableAction += DisableEnemy;
        }
    }
}