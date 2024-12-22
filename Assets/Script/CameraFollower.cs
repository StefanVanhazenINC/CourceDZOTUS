using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour,IGameLateUpdateListener
{
    [SerializeField] private Camera _targetCamera;

    [SerializeField] private Character _character;

    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _defaultPositionX;
    private Vector3 _workSpace = new();

    public void OnLateUpdate(float deltaTime)
    {
        _workSpace.Set(_defaultPositionX, _character.Position.y, _character.Position.z);
        _targetCamera.transform.position = _workSpace + _offset;
    }

    //private void LateUpdate()
    //{
    //    _workSpace.Set(_defaultPositionX, _character.Position.y, _character.Position.z);
    //    _targetCamera.transform.position = _workSpace + _offset;
    //}

}
