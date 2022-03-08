using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public class BadBonus : MonoBehaviour, IInteractive
    {
        public bool DeadBonus;

        void Start()
        {
            GameMngr.s_BonusMngr.BadBonuses.Add(this);
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
            if (DeadBonus) GameMngr.s_BonusMngr.Lose();
            else GameMngr.s_BonusMngr.Freeeeeze();

            gameObject.SetActive(false);
        }
    }
}