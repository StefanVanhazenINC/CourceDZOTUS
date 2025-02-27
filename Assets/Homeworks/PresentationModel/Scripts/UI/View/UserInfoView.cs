using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class UserInfoView : MonoBehaviour
{
    [SerializeField] private TMP_Text _namePlayer;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Image _characterPortrait;

    public void ChangeNamePlayer(string name)
    {
        _namePlayer.text = name;
    }

    public void ChangeDescription(string description)
    {
        _description.text = description;
    }
    public void ChangePortrait(Sprite icon)
    {
        _characterPortrait.sprite = icon;
    }
}
