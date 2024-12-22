using UnityEngine;
using UnityEngine.Events;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
        public float HorizontalDirection { get; private set; }

        public event UnityAction<Vector2> OnMove;
        public event UnityAction OnFire;

        private const string horizontalAxis = "Horizontal";
        private const KeyCode FireKey = KeyCode.Space;

        private Vector2 directionInput = new Vector2();

        private void Update()
        {
            if (Input.GetKeyDown(FireKey)) 
            {
                OnFire?.Invoke();
            }

            HorizontalDirection = Input.GetAxisRaw(horizontalAxis);

            directionInput.Set(HorizontalDirection, 0);
            OnMove?.Invoke(directionInput);


        }
       
    }
}