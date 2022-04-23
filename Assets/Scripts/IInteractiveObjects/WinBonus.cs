using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBonus : IInteractive
{
    public override void ChangeStatus()
    {
        base.ChangeStatus();
        if (IsActive) GameManager.s_GameManager.WinCount += 1;
    }

    public override void Vizualization()
    {
        // добавить какое-то движение или эффекты
    }

    public override void Interaction()
    {
        base.Interaction();
        GameManager.s_GameManager.PickerdUpEvent.Invoke();
    }
}