using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadBonus : IInteractive
{
    public override void Vizualization()
    {
        transform.Rotate(new Vector3(0, - Time.deltaTime * Speed * 60, 0));
        //transform.rotation = Quaternion.Euler(0, transform.rotation.y - Time.time * Speed, 0);
    }

    public override (int id, bool goodBonus) Interaction()
    {
        base.Interaction();
        GameManager.s_GameManager.Freeze();
        return (ID, false);
    }
}