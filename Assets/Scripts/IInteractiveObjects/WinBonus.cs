using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBonus : IInteractive
{
    void Start()
    {
        GameManager.s_GameManager.GoodBonuses.Add(this);
        GameStarted();
        GameManager.s_GameManager.UpdateUI();
    }

    public override void GameStarted()
    {
        base.GameStarted();

        GameManager.s_GameManager.WinCount += 1;
    }

    public override void Vizualization()
    {
        // добавить какое-то движение или эффекты
    }

    public override void Interaction()
    {
        GameManager.s_GameManager.PickerdUpEvent.Invoke();
        base.Interaction();
    }
}