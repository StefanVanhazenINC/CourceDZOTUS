using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IstallerGameManager : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] _permaInstanceInGameManager;

    private void Awake()
    {
        GameManager gameManager = GetComponent<GameManager>();
        IGameListener[] listeners = GetComponentsInChildren<IGameListener>();

        foreach (var listener in listeners)
        {
            gameManager.AddListener(listener);
        }


        for (int i = 0; i < _permaInstanceInGameManager.Length; i++)
        {
            if (_permaInstanceInGameManager[i] is IGameListener) 
            {
                gameManager.AddListener(_permaInstanceInGameManager[i] as IGameListener);
            }
            if (_permaInstanceInGameManager[i] is Character) 
            {
               Character character =  _permaInstanceInGameManager[i] as Character;
               character.OnDeathCharacter += gameManager.FinishGame;
            }
        }

    }
}
