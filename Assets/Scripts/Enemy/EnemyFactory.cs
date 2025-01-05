using ShootEmUp;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory 
{
    private EnemyFacade prefab;
    public EnemyFactory(EnemyFacade prefab)
    {
        this.prefab = prefab;
    }
    public EnemyFacade CreateEnemy(BulletSystem bulletSystem ,Action<EnemyFacade> disableAction) 
    {
        EnemyFacade enemy = GameObject.Instantiate(this.prefab);
        enemy.SetBulletSystem(bulletSystem);
        enemy.gameObject.SetActive(false);
        enemy.AddActionHpEmpty(disableAction);
        return enemy;
    }
}
