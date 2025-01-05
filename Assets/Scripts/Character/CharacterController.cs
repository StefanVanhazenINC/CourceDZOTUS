using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour
    {
        [Header("CharacterModuls")]
        [SerializeField] private HitPointsComponent hitPointsComponent;
        [SerializeField] private WeaponComponent weaponComponent;
        [SerializeField] private TeamComponent teamComponent;
        [SerializeField] private MoveComponent moveComponent;

        [SerializeField] private GameManager gameManager;
        [SerializeField] private InputManager inputManager;

        [SerializeField] private LevelBounds levelBounds;


        [Header("BulletSystem")]
        [SerializeField] private BulletSystem bulletSystem;

        public bool GetIsPlayer { get => teamComponent.IsPlayer; }


        private void OnEnable()
        {
            SetBulletSystem(bulletSystem);
            AddListenerDeathCharacter(OnCharacterDeath);
            inputManager.OnMove += OnMove;
            inputManager.OnFire += OnFire;
        }
        private void OnDisable()
        {
            RemoveListnerDeathCharacter(OnCharacterDeath);
            inputManager.OnMove -= OnMove;
            inputManager.OnFire -= OnFire;
        }
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
        private void OnCharacterDeath(GameObject _)
        {
            this.gameManager.FinishGame();
        } 
    
        private void OnMove(Vector2 direction) 
        {
            if (levelBounds.InBounds((Vector2)moveComponent.transform.position + direction)) 
            {
                moveComponent.MoveByRigidbodyVelocity(direction);
            }
        }

        private void OnFire() 
        {
            weaponComponent.OnFire(teamComponent.IsPlayer);

        }

      
       
     
       

    }
}