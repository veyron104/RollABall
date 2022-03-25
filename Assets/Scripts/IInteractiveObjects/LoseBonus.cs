using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseBonus : IInteractive
{
    void Start()
    {
        GameManager.s_GameManager.BadBonuses.Add(this);
    }

    public override void Vizualization()
    {
        // добавить какое-то движение или эффекты
    }

    public override void Interaction()
    {
        GameManager.s_GameManager.Lose();
        base.Interaction();
    }
}