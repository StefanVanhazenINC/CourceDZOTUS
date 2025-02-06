using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelUpPopView : MonoBehaviour
{
    [SerializeField] private TMP_Text _namePlayer;
    [SerializeField] private TMP_Text _level;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Slider _xpBar;
    [SerializeField] private TMP_Text _xpValue;
    [SerializeField] private Image _characterPortrait;

    [SerializeField] private Transform _statViewParent;

    [SerializeField] private Button _levelUp;
    [SerializeField] private Button _close;

    [SerializeField] private float _timeAnimationXpBar = 0.1f;
    private const string LevelText = "Level: ";
    private const string XpText = "Xp: ";

    public Transform StatViewParent { get => _statViewParent;  }

    public void HidePopUp() 
    {
        gameObject.SetActive(false);
        Debug.Log("off");
    }
    public void ShowPopUp() 
    {
        gameObject.SetActive(true);
    }
    public void ChangeNamePlayer(string name)
    {
        _namePlayer.text = name;
    }
    public void ChangeLevel(string level)
    {
        _level.text = LevelText + level;
    }
    public void ChangeDescription(string description)
    {
        _description.text = description;
    }
    public void ChangePortrait(Sprite icon) 
    {
        _characterPortrait.sprite = icon;   
    }
    public void ChangeLimitBar(float valueMaxXp) 
    {
        _xpBar.maxValue = valueMaxXp;
    }
    public void ChangeValueXpBar(float valueXp)
    {
        _xpBar.DOValue(valueXp,_timeAnimationXpBar);
    }

    public void ChangeValueXp(string currentValueXp, string MaxValueXp) 
    {
        _xpValue.text = XpText + currentValueXp + " / " + MaxValueXp;
    }

    public void SetInteractableLevelUpButton(bool isActive)
    {
        _levelUp.interactable = isActive;
    }
    public void SetButtonAction(UnityAction action) 
    {
        _levelUp.onClick.AddListener(action);
    } 
    public void SetCloseAction(UnityAction action) 
    {
        _close.onClick.AddListener(action);
    }
   
}
