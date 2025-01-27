using ShootEmUp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManagerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameManager>().AsSingle();
    }
}
