using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CharacterContoller : MonoBehaviour,IGameStartListener,IGameResumeListener,IGamePauseListener,IGameFinishListener
{
    [SerializeField] private Character _character;
    [SerializeField] private KeyboardInput _keyboardInput;

    private float _verticalInput = 0 ;
    private float _horizontal;
    //private void OnEnable()
    //{
    //    _keyboardInput.OnInput += OnMove;
    //}

    //private void OnDisable()
    //{
    //    _keyboardInput.OnInput -= OnMove;
    //}

    private void OnMove(int direction) 
    {
        _character.SetPositionToRoad(direction);
    }
   

    public void OnStartGame()
    {
        _keyboardInput.OnInput += OnMove;
       
    }

    public void OnPauseGame()
    {
        _keyboardInput.OnInput -= OnMove;
    }

    public void OnFinishGame()
    {
        _keyboardInput.OnInput -= OnMove;
    }

    public void OnResumeGame()
    {
        _keyboardInput.OnInput += OnMove;
    }
}
