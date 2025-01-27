using System;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class CharacterController : IDisposable
    {
       
     
        [Inject]
        private GameManager gameManager;
        [Inject]
        private LevelBounds levelBounds;

        private InputManager inputManager;

        private TeamComponent teamComponent;
        private MoveComponent moveComponent;
        private HitPointsComponent hitPointsComponent;
        private WeaponComponent weaponComponent;
        public CharacterController(HitPointsComponent hitPoint,
                                                    WeaponComponent weaponComponent, 
                                                                    MoveComponent moveComponent,
                                                                                    TeamComponent teamComponent,
                                                                                            InputManager inputManager)
        {
            this.hitPointsComponent = hitPoint;
            this.weaponComponent = weaponComponent;
            this.moveComponent = moveComponent;
            this.teamComponent = teamComponent;
            this.inputManager = inputManager;

            AddListenerDeathCharacter(OnCharacterDeath);

            inputManager.OnMove += OnMove;
            inputManager.OnFire += OnFire;
        }

        public bool GetIsPlayer { get => teamComponent.IsPlayer; }

     
        public void AddListenerDeathCharacter(Action<GameObject> action)
        {
            hitPointsComponent.hpEmpty += action;
        }
        public void RemoveListnerDeathCharacter(Action<GameObject> action)
        {
            hitPointsComponent.hpEmpty -= action;
        }
        private void OnCharacterDeath(GameObject _)
        {
            this.gameManager.FinishGame();
        } 
    
        private void OnMove(Vector2 direction) 
        {
            if (levelBounds.InBounds((Vector2)moveComponent.Body.position + direction)) 
            {
                moveComponent.MoveByRigidbodyVelocity(direction);
            }
        }

        private void OnFire() 
        {
            weaponComponent.OnFire(teamComponent.IsPlayer);

        }

        public void Dispose()
        {
            RemoveListnerDeathCharacter(OnCharacterDeath);
            inputManager.OnMove -= OnMove;
            inputManager.OnFire -= OnFire;
        }
    }
}