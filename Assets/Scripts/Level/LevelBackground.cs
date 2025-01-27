using System;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public sealed class LevelBackground : IFixedTickable
    {
        private float startPositionY;

        private float endPositionY;

        private float movingSpeedY;

        private float positionX;

        private float positionZ;

        private Transform myTransform;
        private Transform[]objectBackground;

        private Params m_params;

        public LevelBackground(Transform bodyTransform,Transform[] objectBackground, Params @params)
        {
            this.objectBackground = objectBackground;
            m_params = @params;


            this.startPositionY = this.m_params.m_startPositionY;
            this.endPositionY = this.m_params.m_endPositionY;
            this.movingSpeedY = this.m_params.m_movingSpeedY;
            this.myTransform = bodyTransform;
            var position = this.myTransform.position;
            this.positionX = position.x;
            this.positionZ = position.z;

        }

        public void FixedTick()
        {
            for (int i = 0; i < objectBackground.Length; i++)
            {
                if (this.objectBackground[i].localPosition.y <= this.endPositionY)
                {
                    this.objectBackground[i].localPosition = new Vector3(
                        this.positionX,
                        this.startPositionY,
                        this.positionZ
                    );
                }

                this.objectBackground[i].localPosition -= new Vector3(
                    this.positionX,
                    this.movingSpeedY * Time.fixedDeltaTime,
                    this.positionZ
                );
            }
        }

        [Serializable]
        public sealed class Params
        {
            [SerializeField]
            public float m_startPositionY;

            [SerializeField]
            public float m_endPositionY;

            [SerializeField]
            public float m_movingSpeedY;
        }
    }
}