using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatView : MonoBehaviour
{
    [SerializeField] private TMP_Text _title; 
    [SerializeField] private TMP_Text _value;

    public void ChangeTitle(string title) 
    {
        _title.text = title;
    }
    public void ChangeValue(string title)
    {
        _value.text = title;    
    }
}
