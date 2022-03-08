using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public sealed class GoodBonus : MonoBehaviour, IInteractive
    {
        public bool WinBonus;

        void Start()
        {
            GetBonus(false);
        }

        public void GetBonus(bool restarted)
        {
            if (WinBonus)
            {
                GameMngr.s_BonusMngr.WinCount += 1;
            }
            if (!restarted)
            {
                GameMngr.s_BonusMngr.UpdateUI();
                GameMngr.s_BonusMngr.GoodBonuses.Add(this);
            }
        }

        public void Vizualization()
        {
            // Add bonus
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) Interaction();
        }

        public void Interaction()
        {
            if (WinBonus) GameMngr.s_BonusMngr.Win();
            else GameMngr.s_BonusMngr.SpeedUp();

            gameObject.SetActive(false);
        }
    }
}
