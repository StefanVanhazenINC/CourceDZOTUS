using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class MoveComponent 
    {
       
        public GameObject _character;

      
        private Rigidbody2D rb2D;

       
        private float speed = 5.0f;

        public MoveComponent(GameObject character, Rigidbody2D rb2D, float speed)
        {
            _character = character;
            this.rb2D = rb2D;
            this.speed = speed;
        }

        public Transform Body { get => _character.transform;  }

        public void MoveByRigidbodyVelocity(Vector2 vector)
        {
            Vector2 nextPosition = (rb2D.position + vector * speed  * Time.fixedDeltaTime) ;
            rb2D.MovePosition(nextPosition);
        }
    }
}