using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour,IGameUpdateListener
{
    [SerializeField] private Transform _character;
    [SerializeField] private float _speedForward;
    [SerializeField] private float _speedJumpSide;
    [SerializeField] private float _distanceToJump;
    [SerializeField] private float _clampX;

    private float _targetXPosition;
    private Vector3 _targetPosition;
    private bool _endMove = true;

    private float _verticalMod = 1;
    private float _herizontalMod = 1;
    public Action OnDeathCharacter;
    public Vector3 Position
    {
        get { return _character.position; }
    }
   
    
    public void SetPositionToRoad(int direction)
    {
        if (_endMove)
        {
            _endMove = false;
            _targetXPosition = _character.position.x + (direction * _distanceToJump);
            if (_targetXPosition > _clampX || _targetXPosition < -_clampX)
            {
                _targetXPosition = _character.position.x;
                _endMove = true;
            }
        }
    }
    public void JumpToPositionRoad(float animSpeed, float delta)
    {
        if (!_endMove)
        {
            _targetPosition = new Vector3(_targetXPosition, _character.position.y, _character.position.z);

            _character.position = Vector3.MoveTowards(_character.position, _targetPosition,( _speedJumpSide * animSpeed) * delta);
            if (Vector3.Distance(_character.position, _targetPosition) < float.Epsilon)
            {
                _endMove = true;
            }
        }
    }
    public void MoveForward(float input,float delta)
    {
        _character.position = Vector3.MoveTowards(_character.position, _character.position + Vector3.forward, (_speedForward * input) * delta);
    }
    //public void Update()
    //{
    //    JumpToPositionRoad(_verticalMod);
    //    MoveForward(_herizontalMod);
    //}

    
    public void OnUpdate(float deltaTime)
    {
        JumpToPositionRoad(_verticalMod, deltaTime);
        MoveForward(_herizontalMod, deltaTime);
    }

    public void Death() 
    {
        OnDeathCharacter?.Invoke();
    }
}
