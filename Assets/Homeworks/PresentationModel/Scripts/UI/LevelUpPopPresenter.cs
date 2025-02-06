using Lessons.Architecture.PM;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;
public class LevelUpPopPresenter : IDisposable
{
    private LevelUpPopView _view;
    private CharacterInfo _characterInfo;
    private PlayerLevel _level;
    private UserInfo _playerInfo;
    private StatView _statViewPrefab;

    private List<StatPresenter> _statPresenterList= new List<StatPresenter>();
    public LevelUpPopPresenter(StatView statViewPrefab,LevelUpPopView view, CharacterInfo characterInfo, PlayerLevel level, UserInfo playerInfo)
    {
        _view = view;
        _statViewPrefab = statViewPrefab;

        ChangeCharacter( characterInfo, level, playerInfo);
    }

    public void ChangeCharacter( CharacterInfo characterInfo, PlayerLevel level, UserInfo playerInfo) 
    {
        _view.ShowPopUp();
        _characterInfo = characterInfo;//stats
        _level = level;
        _playerInfo = playerInfo;

        ClearStat();

        ChangeValueXp();
        LevelUp();
        _view.SetButtonAction(_level.LevelUp);
        ChangeIcon(_playerInfo.Icon);
        ChangeDescription(_playerInfo.Description);
        ChangeNamePlayer(_playerInfo.Name);
        LevelUp();

        _level.OnExperienceChanged += (_) => ChangeValueXp();
        _level.OnLevelUp += LevelUp;

        _playerInfo.OnIconChanged += ChangeIcon;
        _playerInfo.OnDescriptionChanged += ChangeDescription;
        _playerInfo.OnNameChanged += ChangeNamePlayer;


        _characterInfo.OnStatAdded += AddedStat;
        _characterInfo.OnStatRemoved += RemoveStat;

        _view.SetCloseAction(_view.HidePopUp);
    }
   
    public void ChangeNamePlayer(string text)
    {
        _view.ChangeNamePlayer(text);   
    }

    public void ChangeDescription(string text)
    {
        _view.ChangeDescription(text);
    }
    public void ChangeIcon(Sprite icon) 
    {
       _view.ChangePortrait(icon);
    }
    public void LevelUp() 
    {
        _view.ChangeLimitBar(_level.RequiredExperience);
        _view.ChangeLevel(_level.CurrentLevel.ToString());
        ChangeValueXp();
    }
    public void ChangeValueXp() 
    {
        _view.ChangeValueXp(_level.CurrentExperience.ToString(),_level.RequiredExperience.ToString());
        _view.ChangeValueXpBar((float)_level.CurrentExperience);
        _view.SetInteractableLevelUpButton(_level.CanLevelUp());

    }
 
    public void ClearStat() 
    {
        for (int i = 0; i < _statPresenterList.Count; i++)
        {
            _statPresenterList[i].Dispose();
        }
    }
    public void AddedStat(CharacterStat stat) 
    {
        StatView view = GameObject.Instantiate(_statViewPrefab, _view.StatViewParent);
        StatPresenter statPresenter = new StatPresenter(stat, view);
        _statPresenterList.Add(statPresenter);
    }
    public void RemoveStat(CharacterStat stat) 
    {
        for (int i = 0; i < _statPresenterList.Count; i++)
        {
            Debug.Log(_statPresenterList[i].Stat.Name +" "+ stat.Name);
            if (_statPresenterList[i].Stat.Name == stat.Name) 
            {
                _statPresenterList[i].Dispose();
            }
        }
    }

    public void Dispose()
    {
        if (_level != null)
        {
            _level.OnExperienceChanged -= (_) => ChangeValueXp();
            _level.OnLevelUp -= LevelUp;

            _playerInfo.OnIconChanged -= ChangeIcon;
            _playerInfo.OnDescriptionChanged -= ChangeDescription;
            _playerInfo.OnNameChanged -= ChangeNamePlayer;

            _characterInfo.OnStatAdded -= AddedStat;
            _characterInfo.OnStatRemoved -= RemoveStat;

        }
        
        ClearStat();
    }
}
