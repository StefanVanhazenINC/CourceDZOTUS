using Lessons.Architecture.PM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;

[CreateAssetMenu(menuName = "Config/new CharacterConfig", fileName ="Character Config")]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private CharacterInfo _characterInfo;
    [SerializeField] private PlayerLevel _level;
    [SerializeField] private UserInfo _playerInfo;

    public CharacterInfo CharacterInfo { get => _characterInfo; }
    public PlayerLevel Level { get => _level;  }
    public UserInfo PlayerInfo { get => _playerInfo;}
}
