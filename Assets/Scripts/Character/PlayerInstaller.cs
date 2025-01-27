using ShootEmUp;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using CharacterController = ShootEmUp.CharacterController;

public class PlayerInstaller : MonoInstaller
{
    [Header("Hit Point")]
    [SerializeField] private int hitPoints = 5;

    [Header("Weapon")]
    [SerializeField] private BulletConfig bulletConfig;
    [SerializeField] private Transform firePoint;

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

        Container.Bind<CharacterController>().AsSingle().NonLazy();
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
        Container.Bind<HitPointsComponent>().AsSingle().WithArguments(body,hitPoints);
    }
}
