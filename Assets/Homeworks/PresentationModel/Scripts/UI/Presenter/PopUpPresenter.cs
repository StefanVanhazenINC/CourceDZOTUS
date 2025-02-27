using Lessons.Architecture.PM;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;

public class PopUpPresenter : IDisposable
{
    private PopUpView _popUpView;


    private StatView _statViewPrefab;

    private CharacterInfoPresenter _characterInfo;

    private LevelUpPopPresenter _levelPresenter;
    private LevelUpPopView _view;

  
    private UserInfoPresenter _userInfoPresenter;
    private UserInfoView _userInfoView;
    public PopUpPresenter(StatView statViewPrefab, PopUpView  popUpView, UserInfoView userInfoView, LevelUpPopView view, CharacterInfo characterInfo, 
                                                                        PlayerLevel level, UserInfo userInfo )
    {
        _view = view;
        _statViewPrefab = statViewPrefab;
        _popUpView = popUpView;
        _userInfoView = userInfoView;

        ChangeCharacter(characterInfo,  level,userInfo);
    }

    public void ChangeCharacter(CharacterInfo characterInfo, PlayerLevel level, UserInfo userInfo)
    {
      
        _levelPresenter = new LevelUpPopPresenter(level, _view);
        _characterInfo = new CharacterInfoPresenter( characterInfo, _statViewPrefab, _popUpView.StatViewParent);
        _userInfoPresenter = new UserInfoPresenter(userInfo, _userInfoView);

        _popUpView.ShowPopUp();
        _popUpView.SetCloseAction(_popUpView.HidePopUp);
    }


    public void Dispose()
    {
    }
}
