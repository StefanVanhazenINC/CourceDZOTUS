using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : IFixedTickable
    {
        [Inject]
        private MoveComponent moveComponent;

        
        private GameObject _body;
        public bool IsReached
        {
            get { return this.isReached; }
        }


        private Vector2 destination;

        private bool isReached;

        public EnemyMoveAgent(GameObject body)
        {
            _body = body;
        }

        public void SetDestination(Vector2 endPoint)
        {
            this.destination = endPoint;
            this.isReached = false;
        }

        public void FixedTick()
        {
            if (this.isReached)
            {
                return;
            }

            var vector = this.destination - (Vector2)_body.transform.position;
            if (vector.magnitude <= 0.25f)
            {
                this.isReached = true;
                return;
            }

            var direction = vector.normalized;
            this.moveComponent.MoveByRigidbodyVelocity(direction);
        }
    }
}