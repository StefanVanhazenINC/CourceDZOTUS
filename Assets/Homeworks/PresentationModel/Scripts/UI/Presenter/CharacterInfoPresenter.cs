using Lessons.Architecture.PM;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;

public class CharacterInfoPresenter : IDisposable
{
    private CharacterInfo _characterInfo;
    private List<StatPresenter> _statPresenterList = new List<StatPresenter>();
    private StatView _statViewPrefab;
    private Transform _parentView;
    public CharacterInfoPresenter( CharacterInfo characterInfo, StatView statViewPrefab, Transform parentView)
    {
        _characterInfo = characterInfo;
        _statViewPrefab = statViewPrefab;
        _parentView = parentView;

        ClearStat();

        _characterInfo.OnStatAdded += AddedStat;
        _characterInfo.OnStatRemoved += RemoveStat;


    }
    public void AddedStat(CharacterStat stat)
    {
        StatView view = GameObject.Instantiate(_statViewPrefab, _parentView);
        StatPresenter statPresenter = new StatPresenter(stat, view);
        _statPresenterList.Add(statPresenter);
    }
    public void RemoveStat(CharacterStat stat)
    {
        for (int i = 0; i < _statPresenterList.Count; i++)
        {
            Debug.Log(_statPresenterList[i].Stat.Name + " " + stat.Name);
            if (_statPresenterList[i].Stat.Name == stat.Name)
            {
                _statPresenterList[i].Dispose();
            }
        }
    }
    public void ClearStat()
    {
        for (int i = 0; i < _statPresenterList.Count; i++)
        {
            _statPresenterList[i].Dispose();
        }
    }

    public void Dispose()
    {
        _characterInfo.OnStatAdded -= AddedStat;
        _characterInfo.OnStatRemoved -= RemoveStat;
        ClearStat();
    }
}
