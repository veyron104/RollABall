using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBonus : IInteractive
{
    bool up = true;

    public override void ChangeStatus()
    {
        base.ChangeStatus();
        if (IsActive) GameManager.s_GameManager.WinCount += 1;
    }

    public override void Vizualization()
    {
        if (up)
        {
            transform.position += Vector3.up * Time.deltaTime * Speed;
            if (transform.position.y > 3) up = false;
        }
        else
        {
            transform.position -= Vector3.up * Time.deltaTime * Speed;
            if (transform.position.y < 1) up = true;
        }
    }

    public override (int id, bool goodBonus) Interaction()
    {
        base.Interaction();
        GameManager.s_GameManager.PickerdUpEvent.Invoke();
        return (ID, true);
    }
}