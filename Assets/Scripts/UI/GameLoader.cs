using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    [SerializeField]
    Transform _buttonsPanel;
    [SerializeField]
    PlayerButton _playerButtonPref;
    Dictionary<string, PlayerData> _players = new Dictionary<string, PlayerData>();
    Dictionary<string, PlayerButton> _playerButtons = new Dictionary<string, PlayerButton>();
    [SerializeField]
    GameObject _playerCreatePanel;
    string _path;

    public void LoadGame()
    {
        _path = Application.dataPath + "/Players.json";
        gameObject.SetActive(true);
        if (File.Exists(_path))
        {
            var jsonNamesFormatter = new DataContractJsonSerializer(typeof(Dictionary<string, PlayerData>));
            using (var file = new FileStream(_path, FileMode.Open))
            {
                _players = jsonNamesFormatter.ReadObject(file) as Dictionary<string, PlayerData>;
            }

            foreach (var player in _players)
            {
                if (!_playerButtons.ContainsKey(player.Key)) AddPlayerButton(player.Key);
            }
        }
        else _playerCreatePanel.SetActive(true);
    }

    public void StartGame(string nickName)
    {
        GameManager.s_GameManager.StartGame(_players[nickName]);
        gameObject.SetActive(false);
    }

    public void RestartGame(string nickName)
    {
        _players[nickName].RestartGame();
        GameManager.s_GameManager.StartGame(_players[nickName]);
    }

    public void SaveGame()
    {
        _players[GameManager.s_GameManager.NickName].SaveData();
    }

    public void SaveData()
    {
        var jsonFormatter = new DataContractJsonSerializer(typeof(Dictionary<string, PlayerData>));
        using (var file = new FileStream(_path, FileMode.Create))
        {
            jsonFormatter.WriteObject(file, _players);
        }
    }

    public void CreateNewPlayer(string nickName)
    {
        if (_players.ContainsKey(nickName)) ErrorMessage.s_ErrorMessage.ShowMessage("Такой игрок уже существует");
        else
        {
            _players.Add(nickName, new PlayerData(nickName));
            AddPlayerButton(nickName);
        }
    }

    void AddPlayerButton(string nickName)
    {
        PlayerButton tempButton = Instantiate(_playerButtonPref, _buttonsPanel);
        tempButton.UpdateInfo(this, nickName);
        _playerButtons.Add(nickName, tempButton);
    }
}