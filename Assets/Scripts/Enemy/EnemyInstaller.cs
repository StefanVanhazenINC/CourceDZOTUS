using ShootEmUp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
    [Header("Hit Point")]
    [SerializeField] private int hitPoints = 5;

    [Header("Weapon")]
    [SerializeField] private BulletConfig bulletConfig;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float countdown = 2;

    [Header("Move")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 5;
    [SerializeField] private GameObject body;

    [Header("Team")]
    [SerializeField] private bool isPlayer;
    public override void InstallBindings()
    {
        HitPointsComponentInstaller();
        WeaponComponentInstaller();
        TeamComponentInstaller();
        MoveComponentInstaller();
        EnemyMoveInstaller();
        EnemyAttackInstaller();
    }

    public void EnemyMoveInstaller() 
    {
        Container.BindInterfacesAndSelfTo<EnemyMoveAgent>().AsSingle().WithArguments(body).NonLazy();
    }
    public void EnemyAttackInstaller()
    {

        Container.BindInterfacesAndSelfTo<EnemyAttackAgent>().AsSingle().WithArguments(countdown).NonLazy();
    }
    private void MoveComponentInstaller()
    {
        Container.Bind<MoveComponent>().AsSingle().WithArguments(body, rb, speed);
    }
    private void WeaponComponentInstaller()
    {
        Container.Bind<WeaponComponent>().AsSingle().WithArguments(bulletConfig, firePoint);
    }
    private void TeamComponentInstaller()
    {
        Container.Bind<TeamComponent>().AsSingle().WithArguments(isPlayer);
    }
    private void HitPointsComponentInstaller()
    {
        Container.Bind<HitPointsComponent>().AsSingle().WithArguments(body, hitPoints);
    }
}
