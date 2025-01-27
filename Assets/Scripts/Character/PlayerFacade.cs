using ShootEmUp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerFacade : MonoBehaviour, ICharacterFacade
{
    [Inject]
    private TeamComponent teamComponent;
    [Inject]
    private HitPointsComponent hitPointsComponent;

    public HitPointsComponent HitPointsComponent { get => hitPointsComponent;  }

    public bool SameTeam(bool isPlayer)
    {
        bool sameTeam = teamComponent.IsPlayer == isPlayer ? true : false;
        return sameTeam;
    }

    public void TakeDamage(int value)
    {
        hitPointsComponent.TakeDamage(value);
    }
}
