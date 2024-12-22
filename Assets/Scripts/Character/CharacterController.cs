using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour
    {
        [SerializeField] private GameObject character;

        [SerializeField] private GameManager gameManager;
        [SerializeField] private InputManager inputManager;
        [SerializeField] private LevelBounds _levelBounds;

        [Header("BulletSystem")]
        [SerializeField] private BulletSystem bulletSystem;


        private CharacterFacad characterFacad;

        private void Awake()
        {
            characterFacad = character.GetComponent<CharacterFacad>();
        }

        private void OnEnable()
        {
            characterFacad.SetBulletSystem(bulletSystem);
            characterFacad.AddListenerDeathCharacter(OnCharacterDeath);
            inputManager.OnMove += OnMove;
            inputManager.OnFire += OnFire;

        }

        private void OnDisable()
        {
            characterFacad.RemoveListnerDeathCharacter(OnCharacterDeath);
            inputManager.OnMove -= OnMove;
            inputManager.OnFire -= OnFire;

        }

        private void OnCharacterDeath(GameObject _)
        {
            this.gameManager.FinishGame();
        } 
    
        private void OnMove(Vector2 direction) 
        {
            characterFacad.Move(direction);
        }

        private void OnFire() 
        {
            characterFacad.Fire();
        }
       
    }
}