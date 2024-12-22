using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState 
{
    OFF = 0,
    PLAYING = 1,
    PAUSED = 2,
    FINISHED = 3,

}
public class GameManager : MonoBehaviour
{

    [SerializeField] private GameState _gameState;


    private List<IGameListener> _listeners = new ();
    private List<IGameUpdateListener> _updates = new ();
    private List<IGameLateUpdateListener> _lateUpdates= new ();

    public GameState State 
    {
        get { return _gameState; }
    }

    private void Update()
    {
        if (_gameState != GameState.PLAYING) 
        {
            return;
        }
        var deltaTime = Time.deltaTime;
        for (int i = 0; i < _updates.Count; i++)
        {
            _updates[i].OnUpdate(deltaTime);
        }
    }
    private void LateUpdate()
    {
        if (_gameState != GameState.PLAYING)
        {
            return;
        }
        var deltaTime = Time.deltaTime;
        for (int i = 0; i < _lateUpdates.Count; i++)
        {
            _lateUpdates[i].OnLateUpdate(deltaTime);
        }
    }

    public void AddListener(IGameListener listener) 
    {
        if (listener == null) 
        {
            return;
        }

        _listeners.Add(listener);   
        if (listener is IGameUpdateListener updataListeners ) 
        {
            _updates.Add(updataListeners);
        }
        if (listener is IGameLateUpdateListener lateUpdataListeners)
        {
            _lateUpdates.Add(lateUpdataListeners);
        }
    }

    [ContextMenu("StartGame")]
    public void StartGame() 
    {
        foreach (var listener in _listeners) 
        {
            if (listener is IGameStartListener startListeners) 
            {
                startListeners.OnStartGame();
            }
        }
        _gameState = GameState.PLAYING;
    }
    [ContextMenu("PauseGame")]
    public void PauseGame()
    {
        
        foreach (var listener in _listeners)
        {
            if (listener is IGamePauseListener pauseListeners)
            {
                pauseListeners.OnPauseGame();
            }
        }


        _gameState = GameState.PAUSED;
    }

    [ContextMenu("ResumeGame")]
    public void ResumeGame()
    {


        foreach (var listener in _listeners)
        {
            if (listener is IGameResumeListener resumeListeners)
            {
                resumeListeners.OnResumeGame();
            }
        }
        _gameState = GameState.PLAYING;
    }

    [ContextMenu("FinishGame")]
    public void FinishGame()
    {

        foreach (var listener in _listeners)
        {
            if (listener is IGameFinishListener finishListeners)
            {
                finishListeners.OnFinishGame();
            }
        }

        _gameState = GameState.FINISHED;

    }
}
