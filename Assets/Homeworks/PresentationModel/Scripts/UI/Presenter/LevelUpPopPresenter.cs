using Lessons.Architecture.PM;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;
public class LevelUpPopPresenter : IDisposable
{
    private PlayerLevel _level;
    private LevelUpPopView _view;

    public LevelUpPopPresenter(PlayerLevel level, LevelUpPopView view)
    {
        _level = level;
        _view = view;
        Debug.Log(_view+" +" + _level);
        _view.SetButtonAction(_level.LevelUp);

        ChangeValueXp();
        LevelUp();


        _level.OnExperienceChanged += (_) => ChangeValueXp();
        _level.OnLevelUp += LevelUp;
    }
    public void LevelUp()
    {
        _view.ChangeLimitBar(_level.RequiredExperience);
        _view.ChangeLevel(_level.CurrentLevel.ToString());
        ChangeValueXp();
    }
    public void ChangeValueXp()
    {
        _view.ChangeValueXp(_level.CurrentExperience.ToString(), _level.RequiredExperience.ToString());
        _view.ChangeValueXpBar((float)_level.CurrentExperience);
        _view.SetInteractableLevelUpButton(_level.CanLevelUp());

    }
    public void Dispose()
    {
        if (_level!=null) 
        {
            _level.OnExperienceChanged -= (_) => ChangeValueXp();
            _level.OnLevelUp -= LevelUp;
        }
    }
}
