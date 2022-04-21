using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerButton : MonoBehaviour
{
    [SerializeField]
    Text _nickNameText;

    GameLoader _gameLoader;

    public void UpdateInfo(GameLoader gameLoader, string nickName)
    {
        _gameLoader = gameLoader;
        _nickNameText.text = nickName;
    }

    public void StartGame()
    {
        _gameLoader.StartGame(_nickNameText.text);
    }
}