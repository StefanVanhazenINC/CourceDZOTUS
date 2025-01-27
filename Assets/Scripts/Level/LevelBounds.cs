using UnityEngine;

namespace ShootEmUp
{
    public sealed class LevelBounds 
    {
        [SerializeField]
        private Transform leftBorder;

        [SerializeField]
        private Transform rightBorder;

        [SerializeField]
        private Transform downBorder;

        [SerializeField]
        private Transform topBorder;

        public LevelBounds(Transform leftBorder, Transform rightBorder, Transform downBorder, Transform topBorder)
        {
            this.leftBorder = leftBorder;
            this.rightBorder = rightBorder;
            this.downBorder = downBorder;
            this.topBorder = topBorder;
        }

        public bool InBounds(Vector3 position)
        {
            var positionX = position.x;
            var positionY = position.y;

            return positionX > this.leftBorder.position.x
                   && positionX < this.rightBorder.position.x
                   && positionY > this.downBorder.position.y
                   && positionY < this.topBorder.position.y;
        }
    }
}