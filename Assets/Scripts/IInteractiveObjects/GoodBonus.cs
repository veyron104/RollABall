using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GoodBonus : IInteractive
{
    void Start()
    {
        GameManager.s_GameManager.GoodBonuses.Add(this);
        GameStarted();
    }

    public override void Vizualization()
    {
        // добавить какое-то движение или эффекты
    }

    public override void Interaction()
    {
        GameManager.s_GameManager.SpeedUp();
        base.Interaction();
    }
}