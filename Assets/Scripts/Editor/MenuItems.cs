using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuItems
{
    [MenuItem("RollABall/Обновить списки бонусов")]
    public static void Check()
    {
        GameObject go = GameObject.Find("Canvas");
        if (go == null)
        {
            Debug.Log("На сцене нет канваса!!");
            return;
        }
        BonusFinder finder = go.GetComponent<BonusFinder>();
        if (finder == null)
        {
            Debug.Log("На канвасе нет компонента BonusFinder!!");
            return;
        }
        finder.ComponentChecker();
    }
}