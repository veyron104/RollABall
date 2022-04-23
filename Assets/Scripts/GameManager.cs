using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GoodBonusPickerdUpEvent : UnityEvent { }
public class GameManager : MonoBehaviour
{
    public static GameManager s_GameManager;
    public GameLoader GameLoader;
    public int WinCount = 0;
    public string NickName = "";
    public List<IInteractive> GoodBonuses = new List<IInteractive>();
    public List<IInteractive> BadBonuses = new List<IInteractive>();
    public PlayerBall Player;
    Vector3 _startPosition = new Vector3(7.86f, 1, 19.22f);
    public Text WinCountTxt;
    public GameObject MsgBox;
    public Text MsgBoxTxt;

    public GoodBonusPickerdUpEvent PickerdUpEvent = new GoodBonusPickerdUpEvent();

    public static string Path()
    {
        return "123";
    }
    void Awake()
    {
        s_GameManager = this;
        PickerdUpEvent.AddListener(Win);
    }
    void Start()
    {
        GameLoader.LoadGame();
    }
    public void StartGame(PlayerData playerData)
    {
        NickName = playerData.NickName;
        UpdateList(playerData.GoodBonuses, ref GoodBonuses);
        UpdateList(playerData.BadBonuses, ref BadBonuses);
        UpdateUI();
        Player.StartGame();
    }

    void UpdateList(List<BonusData> baseList, ref List<IInteractive> updatingList)
    {
        for (int i = 0; i < baseList.Count; i++)
        {
            updatingList[i].GameLoaded(baseList[i].IsActive);
            updatingList[i].ChangeStatus();
        }
    }

    public void RestartGame()
    {
        MsgBox.SetActive(false);
        Player.transform.position = _startPosition;
        GameLoader.RestartGame(NickName);
    }

    void Update()
    {
        for (int i = 0; i < GoodBonuses.Count; i++)
        {
            GoodBonuses[i].Vizualization();
        }

        for (int i = 0; i < BadBonuses.Count; i++)
        {
            BadBonuses[i].Vizualization();
        }
    }

    public void Win()
    {
        GameLoader.SaveGame();
        StopAllCoroutines();
        WinCount -= 1;
        UpdateUI();
        if (WinCount == 0)
        {
            Player.Win();
            ShowMessege("Поздравляю! Вы выиграли!!!!");
        }
    }

    public void UpdateUI()
    {
        WinCountTxt.text = "Осталось собрать: " + WinCount;
    }

    public void Lose()
    {
        GameLoader.SaveGame();
        StopAllCoroutines();
        Player.Lose();
        ShowMessege("Вы проиграли!");
    }

    void ShowMessege(string msg)
    {
        MsgBox.SetActive(true);
        MsgBoxTxt.text = msg;
    }

    public void SpeedUp()
    {
        GameLoader.SaveGame();
        StartCoroutine(SpeedUpCor());
    }

    IEnumerator SpeedUpCor()
    {
        Player.Speed *= 2;
        yield return new WaitForSeconds(3);
        Player.Speed /= 2;
    }

    public void Freeze()
    {
        GameLoader.SaveGame();
        StartCoroutine(FreezeCor());
    }

    IEnumerator FreezeCor()
    {
        Player.Speed /= 2;
        yield return new WaitForSeconds(3);
        Player.Speed *= 2;
    }

    public void OnDisable()
    {
        GameLoader.SaveData();
    }

    public void QuitGame()
    {
        GameLoader.SaveData();
        Application.Quit();
    }
}