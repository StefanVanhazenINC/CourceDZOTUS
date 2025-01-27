using ShootEmUp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelBoundsInstaller : MonoInstaller
{
    [SerializeField]
    private Transform leftBorder;

    [SerializeField]
    private Transform rightBorder;

    [SerializeField]
    private Transform downBorder;

    [SerializeField]
    private Transform topBorder;

    public override void InstallBindings()
    {
       Container.Bind<LevelBounds>().AsSingle().WithArguments(leftBorder, rightBorder, downBorder, topBorder);
    }
}
