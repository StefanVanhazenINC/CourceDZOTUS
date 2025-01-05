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

    

    [SerializeField] private int _delayToPlay;

    private bool _isPaused = false;
  
 
    private IEnumerator StartGameWhithCooldown() 
    {
        for (int time = _delayToPlay; time >= 0; time--)
        {
            yield return new WaitForSeconds(1);
            Debug.Log(time);
        }
        _gameManager.StartGame();
    }
    public void StartGame() 
    {

        StartCoroutine(StartGameWhithCooldown());
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


    }
    public void ResumeGame() 
    {
        _gameManager.ResumeGame();  
       
    }
}
