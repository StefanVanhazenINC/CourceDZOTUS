using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IstallerGameManager : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] _InstanceInGameManager;

    private void Awake()
    {
        GameManager gameManager = GetComponent<GameManager>();
        IGameListener[] listeners = GetComponentsInChildren<IGameListener>();

        foreach (var listener in listeners)
        {
            gameManager.AddListener(listener);
        }


        for (int i = 0; i < _InstanceInGameManager.Length; i++)
        {
            if (_InstanceInGameManager[i] is IGameListener) 
            {
                gameManager.AddListener(_InstanceInGameManager[i] as IGameListener);
            }
            if (_InstanceInGameManager[i] is Character) 
            {
               Character character =  _InstanceInGameManager[i] as Character;
               character.OnDeathCharacter += gameManager.FinishGame;
            }
        }

    }
}
