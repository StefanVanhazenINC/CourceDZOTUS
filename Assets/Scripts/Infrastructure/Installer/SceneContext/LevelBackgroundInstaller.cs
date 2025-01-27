using ShootEmUp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
using static ShootEmUp.LevelBackground;

public class LevelBackgroundInstaller : MonoInstaller
{
    [SerializeField] private Transform[] objectBackground;
    [SerializeField] private Params m_params;
    [SerializeField] private Transform bodyTransform;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<LevelBackground>().AsSingle().WithArguments(bodyTransform, objectBackground, m_params).NonLazy();
    }
}
