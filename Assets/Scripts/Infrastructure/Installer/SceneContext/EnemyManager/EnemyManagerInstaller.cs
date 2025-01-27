using ShootEmUp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyManagerInstaller : MonoInstaller 
{
    [SerializeField] private EnemyFacade _enemyPrefab;
    [SerializeField] private Transform _poolParent;
    [SerializeField] private int _enemyCount = 7;

    [Header("EnemyPositions")]
    [SerializeField]
    private Transform[] spawnPositions;

    [SerializeField]
    private Transform[] attackPositions;


    public override void InstallBindings()
    {
        BindFactory();
        BindEnemyPosition();
        BindEnemyManager();
    }
    private void BindEnemyManager() 
    {
        Container.Bind<EnemyManager>().AsSingle().WithArguments(_enemyCount,this).NonLazy() ;
    }
    private void BindEnemyPosition() 
    {
        Container.Bind<EnemyPositions>().AsSingle().WithArguments(spawnPositions, attackPositions).NonLazy() ;

    }
    private void BindFactory() 
    {
        Container.BindFactory<EnemyFacade, EnemyFactory>().FromMonoPoolableMemoryPool(
           x => x.WithInitialSize(_enemyCount).WithMaxSize(_enemyCount).FromComponentInNewPrefab(_enemyPrefab).UnderTransform(_poolParent)).NonLazy();
    }
}

public class EnemyFactory : PlaceholderFactory<EnemyFacade> { }