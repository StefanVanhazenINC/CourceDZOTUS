using Lessons.Architecture.PM;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;


public class UserInfoPresenter : IDisposable
{
    private UserInfo _userInfo;
    private UserInfoView _userInfoView;

    public UserInfoPresenter(UserInfo userInfo, UserInfoView userInfoView)
    {
        _userInfo = userInfo;
        _userInfoView = userInfoView;

        ChangeIcon(_userInfo.Icon);
        ChangeDescription(_userInfo.Description);
        ChangeNamePlayer(_userInfo.Name);


        _userInfo.OnIconChanged += ChangeIcon;
        _userInfo.OnDescriptionChanged += ChangeDescription;
        _userInfo.OnNameChanged += ChangeNamePlayer;

    }
    public void ChangeNamePlayer(string text)
    {
        _userInfoView.ChangeNamePlayer(text);
    }

    public void ChangeDescription(string text)
    {
        _userInfoView.ChangeDescription(text);
    }
    public void ChangeIcon(Sprite icon)
    {
        _userInfoView.ChangePortrait(icon);
    }



    public void Dispose()
    {

        _userInfo.OnIconChanged -= ChangeIcon;
        _userInfo.OnDescriptionChanged -= ChangeDescription;
        _userInfo.OnNameChanged -= ChangeNamePlayer;

    }
}
