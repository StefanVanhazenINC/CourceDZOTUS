using UnityEngine;

namespace ShootEmUp
{

    public struct BulletData
    {
        public Vector2 position;
        public Vector2 velocity;
        public Color color;
        public int physicsLayer;
        public int damage;
        public bool isPlayer;//=======
    }
}