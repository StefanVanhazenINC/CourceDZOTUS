using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveComponent : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D rb2D;

        [SerializeField]
        private float speed = 5.0f;
        
        public void MoveByRigidbodyVelocity(Vector2 vector)
        {
            Vector2 nextPosition = (rb2D.position + vector * speed  * Time.fixedDeltaTime) ;
            rb2D.MovePosition(nextPosition);
        }
    }
}