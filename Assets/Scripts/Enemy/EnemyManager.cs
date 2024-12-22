using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField]
        //private EnemyPool enemyPool;
        private EnemyFabrica enemyFabrica;
        [SerializeField]
        private GameObject character;


       // private readonly HashSet<EnemyFacad> m_activeEnemies = new();

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                var enemy = this.enemyFabrica.SpawnEnemy();
                if (enemy != null)
                {
                    enemy.SetTarget(character);
                }
                //if (enemy != null)
                //{
                //    if (this.m_activeEnemies.Add(enemy))
                //    {
                //        enemy.SetTarget(character);
                //    }    
                //}
            }
        }
    }
}