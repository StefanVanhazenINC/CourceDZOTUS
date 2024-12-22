using ShootEmUp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFabrica : MonoBehaviour
{
    [SerializeField] private int countPool = 7;
    [Header("Spawn")]
    [SerializeField]
    private EnemyPositions enemyPositions;

    [SerializeField]
    private Transform worldTransform;

    [Header("Pool")]
    [SerializeField]
    private Transform container;

    [SerializeField]
    private EnemyFacad prefab;
    [SerializeField]
    private BulletSystem bulletSystem;

    private readonly Queue<EnemyFacad> enemyPool = new();

    private void Awake()
    {
        for (var i = 0; i < countPool; i++)
        {
            var enemy = Instantiate(this.prefab, this.container);
            enemy.SetBulletSystem(bulletSystem);
            enemy.AddActionHpEmpty(UnspawnEnemy);
            this.enemyPool.Enqueue(enemy);
        }
    }

    public EnemyFacad SpawnEnemy()
    {
        if (!this.enemyPool.TryDequeue(out var enemy))
        {
            return null;
        }

        enemy.transform.SetParent(this.worldTransform);

        var spawnPosition = this.enemyPositions.RandomSpawnPosition();
        enemy.transform.position = spawnPosition.position;

        var attackPosition = this.enemyPositions.RandomAttackPosition();
        enemy.SetDestination(attackPosition.position);

        return enemy;
    }

    public void UnspawnEnemy(GameObject enemy)
    {
        enemy.transform.SetParent(this.container);
        this.enemyPool.Enqueue(enemy.GetComponent<EnemyFacad>());
    }
}
