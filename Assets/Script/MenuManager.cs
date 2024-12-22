using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    [SerializeField] private Button _startButton;
    [SerializeField] private Button _pauseButton;

    

    [SerializeField] private float _delayToPlay;
    private float _timerDelayToPlay;

    private bool _isPlaying = true;
    private bool _isPaused = false;
    private void Start() 
    {
        _timerDelayToPlay = _delayToPlay;
    }
    private void Update()
    {
        if (!_isPlaying) 
        {
            if (_timerDelayToPlay > 0)
            {
                _timerDelayToPlay -= Time.deltaTime;
                Debug.Log(Mathf.CeilToInt(_timerDelayToPlay));
            }
            else 
            {
                _isPlaying = true;
                _gameManager.StartGame();
            }
        }
      //
       // _timerDelayToPlay -= Time.deltaTime;
       // Debug.Log(Mathf. ;
    }
    public void StartGame() 
    {
        _isPlaying = false;
        if (_startButton)
        {
            _startButton.gameObject.SetActive(false);
        }
        if (_pauseButton)
        {
            _pauseButton.gameObject.SetActive(true);
        }
    }
    public void PauseGame() 
    {
        if (!_isPaused)
        {
            _gameManager.PauseGame();
            _isPaused = true;
        }
        else 
        {
            _isPaused = false;
            ResumeGame();
        }

        //if (_isPlaying)
        //{
        //    _gameManager.PauseGame();
        //    _timerDelayToPlay = _delayToPlay;

        //}
        //else 
        //{
        //    _isPlaying = false;
        //}

    }
    public void ResumeGame() 
    {
        _gameManager.ResumeGame();  
       
    }
}
