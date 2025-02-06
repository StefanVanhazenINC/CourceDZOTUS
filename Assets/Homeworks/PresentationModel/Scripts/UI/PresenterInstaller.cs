using Lessons.Architecture.PM;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;
public class PresenterInstaller : MonoBehaviour
{
    [SerializeField] private LevelUpPopView _view;
    [SerializeField] private StatView _statViewPrefab;
    [SerializeField] private CharacterConfig _characterConfig;

    private LevelUpPopPresenter _presenter;
 
    [Button]
    public void SetConfig() 
    {
        if (_presenter == null)
        {
            LevelUpPopPresenter presenter = new LevelUpPopPresenter(_statViewPrefab, _view, _characterConfig.CharacterInfo, _characterConfig.Level, _characterConfig.PlayerInfo);
            _presenter = presenter;
        }
        else 
        {
            _presenter.ChangeCharacter(_characterConfig.CharacterInfo, _characterConfig.Level, _characterConfig.PlayerInfo);
        }
    }

    public void OnDisable()
    {
        if (_presenter != null)
        {
            _presenter.Dispose();
        }
    }
}
