using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace ShootEmUp
{
    public sealed class InputManager : ITickable
    {
        public float HorizontalDirection { get; private set; }

        public event UnityAction<Vector2> OnMove;
        public event UnityAction OnFire;

        private const string horizontalAxis = "Horizontal";
        private const KeyCode FireKey = KeyCode.Space;

        private Vector2 directionInput = new Vector2();

      

        public void Tick()
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