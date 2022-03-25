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
    public int WinCount = 0;
    public Material WinMaterial;
    public Material GoodMaterial;
    public Material BadMaterial;
    public Material DeadMaterial;
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

        List<float> myAr = new List<float>();
        try
        {
            myAr[1] = 6;
            Debug.Log(myAr[1]);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Debug.Log("Задание № 1 выполнено");
        }

        int randomNumber;
        try
        {
            randomNumber = NumberGetter(2);
            Debug.Log(randomNumber);
        }
        catch (NorNeededExeption ex)
        {
            Debug.Log("Задание № 4 выполнено: " + ex.Message);
        }
    }

    int NumberGetter(int number)
    {
        if (number % 3 == 0) return number;
        else throw new NorNeededExeption(number);
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
            MsgBox.SetActive(true);
            MsgBoxTxt.text = "Поздравляю! Вы выиграли!!!!";
        }
    }

    public void UpdateUI()
    {
        WinCountTxt.text = "Осталось собрать: " + WinCount;
        Debug.Log("Задание № 3 выполнено");
    }

    public void Lose()
    {
        StopAllCoroutines();
        Player.Dead = true;
        MsgBox.SetActive(true);
        MsgBoxTxt.text = "Вы проиграли!";
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