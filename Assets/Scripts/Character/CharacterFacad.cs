using ShootEmUp;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFacad : MonoBehaviour
{
    [SerializeField] protected HitPointsComponent hitPointsComponent;
    [SerializeField] protected WeaponComponent weaponComponent;
    [SerializeField] protected TeamComponent teamComponent;
    [SerializeField] protected MoveComponent moveComponent;

    
    public bool GetIsPlayer { get => teamComponent.IsPlayer; }

    public void AddListenerDeathCharacter(Action<GameObject> action) 
    {
        hitPointsComponent.hpEmpty += action;
    }
    public void RemoveListnerDeathCharacter(Action<GameObject> action) 
    {
        hitPointsComponent.hpEmpty -= action;
    }
    public void SetBulletSystem(BulletSystem bulletSystem) 
    {
        weaponComponent.SetBulletSystem(bulletSystem);
    }
    public void Move(Vector2 direction) 
    {
        moveComponent.MoveByRigidbodyVelocity(direction);
    }
    public void Fire() 
    {
        weaponComponent.OnFire(teamComponent.IsPlayer);
    }
  

}
