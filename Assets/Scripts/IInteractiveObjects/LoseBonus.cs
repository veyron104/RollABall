using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseBonus : IInteractive
{
    public override void Vizualization()
    {
        // добавить какое-то движение или эффекты
    }

    public override void Interaction()
    {
        base.Interaction();
        GameManager.s_GameManager.Lose();
    }
}