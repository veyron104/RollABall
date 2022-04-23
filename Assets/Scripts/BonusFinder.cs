using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusFinder : MonoBehaviour
{
    public GameManager GM;

    public void ComponentChecker()
    {
        GM.GoodBonuses.Clear();
        GM.BadBonuses.Clear();

        GameObject[] go = GameObject.FindGameObjectsWithTag("Bonus");

        foreach (var item in go)
        {
            IInteractive tempCompinent = CheckComponent(item, out bool goodBonus);
            if (tempCompinent != null)
            {
                if (goodBonus) GM.GoodBonuses.Add(tempCompinent);
                else GM.BadBonuses.Add(tempCompinent);
            }
        }
    }

    IInteractive CheckComponent(GameObject target, out bool goodBonus)
    {
        Component[] components = target.GetComponents<Component>();

        foreach (var item in components)
        {
            if (item.GetType() == typeof(GoodBonus) || item.GetType() == typeof(WinBonus))
            {
                goodBonus = true;
                return (IInteractive)item;
            }

            if (item.GetType() == typeof(BadBonus) || item.GetType() == typeof(LoseBonus))
            {
                goodBonus = false;
                return (IInteractive)item;
            }
        }

        goodBonus = false;
        return null;
    }
}