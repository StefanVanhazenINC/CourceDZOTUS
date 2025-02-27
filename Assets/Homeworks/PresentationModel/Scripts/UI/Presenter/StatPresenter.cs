using Lessons.Architecture.PM;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatPresenter : IDisposable
{
    private CharacterStat _stat;
    private StatView _statView;
    public CharacterStat Stat { get => _stat; }

    public StatPresenter(CharacterStat stat, StatView statView)
    {
        _stat = stat;
        _statView = statView;
        _statView.ChangeTitle(stat.Name);
        _statView.ChangeValue(stat.Value.ToString());
        _stat.OnValueChanged += ChangeValueState;

    }

    public void ChangeValueState(int value) 
    {
        _statView.ChangeValue(value.ToString());
    }

    public void Dispose()
    {
       
        _stat.OnValueChanged -= ChangeValueState;
        GameObject.Destroy(_statView.gameObject);
    }
}
