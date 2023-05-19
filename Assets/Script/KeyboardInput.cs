using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour , IGameUpdateListener
{
    public Action<int> OnInput;


    //private void Update()
    //{
    //    HandleKeyboardInput();
    //}
    private void HandleKeyboardInput() 
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move(-1);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(1);
        }
    }
    private void Move(int direction) 
    {
        OnInput?.Invoke(direction);
    }

    public void OnUpdate(float deltaTime)
    {
        HandleKeyboardInput();
    }
}
