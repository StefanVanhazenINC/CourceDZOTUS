using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        private Transform poolParent;

        private readonly Queue<EnemyFacade> m_enemyPool = new();
        private readonly HashSet<EnemyFacade> m_activeEnemies = new();
        public HashSet<EnemyFacade> ActiveEnemies => m_activeEnemies;

        public EnemyPool(Transform poolParent)
        {
            this.poolParent = poolParent;
        }

        public bool TryGet(out EnemyFacade enemy)
        {
            if (this.m_enemyPool.Count > 0)
            {
                this.m_enemyPool.TryDequeue(out enemy);
                m_activeEnemies.Add(enemy);
                return true;
            }
            enemy = null;
            return false;
        }
        public void AddInPool(EnemyFacade enemy)
        {
            m_activeEnemies.Add(enemy);
        }
        public void ReturnInPool(EnemyFacade enemy)
        {
            if (this.m_activeEnemies.Remove(enemy))
            {
                enemy.transform.SetParent(poolParent);
                this.m_enemyPool.Enqueue(enemy);
                enemy.gameObject.SetActive(false);
            }
        }

        
    }
}