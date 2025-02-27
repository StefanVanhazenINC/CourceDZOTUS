using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class PopUpView : MonoBehaviour
{
    [SerializeField] private Transform _statViewParent;
    [SerializeField] private Button _close;
    public Transform StatViewParent { get => _statViewParent; }

    public void HidePopUp()
    {
        gameObject.SetActive(false);
    }
    public void ShowPopUp()
    {
        gameObject.SetActive(true);
    }
    public void SetCloseAction(UnityAction action)
    {
        _close.onClick.AddListener(action);
    }
}
