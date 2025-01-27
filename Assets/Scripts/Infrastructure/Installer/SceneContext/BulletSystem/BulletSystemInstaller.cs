using ShootEmUp;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BulletSystemInstaller : MonoInstaller
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _bulletParent;
    [SerializeField] private int _poolSize = 25;
    public override void InstallBindings()
    {
        Container.BindFactory<Bullet, BulletFactory>().FromMonoPoolableMemoryPool(
            x => x.WithInitialSize(_poolSize).FromComponentInNewPrefab(_bulletPrefab).UnderTransform(_bulletParent)).NonLazy();

        Container.BindInterfacesAndSelfTo<BulletSystem>().AsSingle();
    }
}
public class BulletFactory : PlaceholderFactory<Bullet> 
{

}