using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Lesson7;

public class GoodBonusPickerdUpEvent : UnityEvent { }
public class GameManager : MonoBehaviour
{
    public static GameManager s_GameManager;
    public int WinCount = 0;
    public List<IInteractive> GoodBonuses = new List<IInteractive>();
    public List<IInteractive> BadBonuses = new List<IInteractive>();
    public PlayerBall Player;
    Vector3 _startPosition = new Vector3(7.86f, 1, 19.22f);
    public Text WinCountTxt;
    public GameObject MsgBox;
    public Text MsgBoxTxt;

    public GoodBonusPickerdUpEvent PickerdUpEvent = new GoodBonusPickerdUpEvent();

    void Awake()
    {
        s_GameManager = this;
        PickerdUpEvent.AddListener(Win);
        string tempStrn = "Пример";
        Debug.Log($"Длина строки \"{tempStrn}\" равна {tempStrn.StringLengh()}");
        Exercise3 ex3 = new Exercise3();
        Exercise4 ex4 = new Exercise4();
    }

    public void StartGame()
    {
        MsgBox.SetActive(false);
        Player.transform.position = _startPosition;
        Player.Rigdbody.isKinematic = false;
        for (int i = 0; i < GoodBonuses.Count; i++)
        {
            GoodBonuses[i].GameStarted();
        }

        for (int i = 0; i < BadBonuses.Count; i++)
        {
            BadBonuses[i].GameStarted();
        }
        UpdateUI();
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
        StopAllCoroutines();
        WinCount -= 1;
        UpdateUI();
        if (WinCount == 0)
        {
            Player.Rigdbody.isKinematic = true;
            ShowMessege("Поздравляю! Вы выиграли!!!!");
        }
    }

    public void UpdateUI()
    {
        WinCountTxt.text = "Осталось собрать: " + WinCount;
    }

    public void Lose()
    {
        StopAllCoroutines();
        Player.Dead = true;
        ShowMessege("Вы проиграли!");
    }

    void ShowMessege(string msg)
    {
        MsgBox.SetActive(true);
        MsgBoxTxt.text = msg;
    }

    public void SpeedUp()
    {
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
        StartCoroutine(FreezeCor());
    }

    IEnumerator FreezeCor()
    {
        Player.Speed /= 2;
        yield return new WaitForSeconds(3);
        Player.Speed *= 2;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

public sealed class NorNeededExeption: Exception
{
    public int number;
    public NorNeededExeption(int val) : base($"Число {val} не кратно трём!")
    {
        number = val;
    }
}