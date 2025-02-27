using Lessons.Architecture.PM;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;
public class PresenterInstaller : MonoBehaviour
{
    [SerializeField] private LevelUpPopView _levelUpView;
    [SerializeField] private PopUpView _popUpView;
    [SerializeField] private StatView _statViewPrefab;
    [SerializeField] private UserInfoView _userInfoView;
    [SerializeField] private CharacterConfig _characterConfig;

    private PopUpPresenter _presenter;
 
    [Button]
    public void SetConfig() 
    {
        if (_presenter == null)
        {
            PopUpPresenter presenter = new PopUpPresenter(_statViewPrefab, _popUpView, _userInfoView,_levelUpView, _characterConfig.CharacterInfo, _characterConfig.Level, _characterConfig.PlayerInfo);
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
