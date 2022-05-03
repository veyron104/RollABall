using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GoodBonus : IInteractive
{
    public override void Vizualization()
    {
        transform.Rotate(new Vector3(0, Time.deltaTime * Speed * 60, 0));
    }

    public override (int id, bool goodBonus) Interaction()
    {
        base.Interaction();
        GameManager.s_GameManager.SpeedUp();
        return (ID, true);
    }
}