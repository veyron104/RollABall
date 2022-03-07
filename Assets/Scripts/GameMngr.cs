using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Debug;

namespace Geekbrains
{
    public class GameMngr : MonoBehaviour
    {
        public static GameMngr s_BonusMngr;
        public int WinCount = 0;
        public Material WinMaterial;
        public Material GoodMaterial;
        public Material BadMaterial;
        public Material DeadMaterial;
        public List<GoodBonus> GoodBonuses = new List<GoodBonus>();
        public List<BadBonus> BadBonuses = new List<BadBonus>();
        public PlayerBall Player;
        Vector3 _startPosition = new Vector3(7.86f, 1, 19.22f);
        public Text WinCountTxt;
        public GameObject MsgBox;
        public Text MsgBoxTxt;

        void Awake()
        {
            int a = 5;
            int b = 7;
            Log($"a = {a}, b = {b}");
            b = (a + (a = b)) - a;
            Log($"a = {a}, b = {b}");
            s_BonusMngr = this;
        }

        public void StartGame()
        {
            MsgBox.SetActive(false);
            Player.transform.position = _startPosition;
            Player.Rigdbody.isKinematic = false;
            for (int i = 0; i < GoodBonuses.Count; i++)
            {
                GoodBonuses[i].gameObject.SetActive(true);
                GoodBonuses[i].GetBonus(true);
            }

            for (int i = 0; i < BadBonuses.Count; i++)
            {
                BadBonuses[i].gameObject.SetActive(true);
            }
            UpdateUI();
        }

        public void UpdateUI()
        {
            WinCountTxt.text = "Осталось собрать: " + WinCount;
        }

        void Update()
        {
            for (int i = 0; i < GoodBonuses.Count; i++)
            {
                GoodBonuses[i].Vizualization();
            }

            for (int i = 0; i < BadBonuses.Count; i++)
            {
                BadBonuses[i].Vizualization();
            }
        }

        public void Win()
        {
            StopAllCoroutines();
            WinCount -= 1;
            UpdateUI();
            if (WinCount == 0)
            {
                Player.Rigdbody.isKinematic = true;
                MsgBox.SetActive(true);
                MsgBoxTxt.text = "Поздравляю! Вы выиграли!!!!";
                Log("Поздравляю! Вы выиграли!!!!");
            }
        }

        public void Lose()
        {
            StopAllCoroutines();
            Player.Dead = true;
            MsgBox.SetActive(true);
            MsgBoxTxt.text = "Вы проиграли!";
            Log("Вы проиграли!");
        }

        public void SpeedUp()
        {
            StartCoroutine(SpeedUpCor());
        }

        IEnumerator SpeedUpCor()
        {
            Player.Speed *= 2;
            Log("SpeedUp!");
            yield return new WaitForSeconds(3);
            Player.Speed /= 2;
            Log("Freeeeeze!");
        }

        public void Freeeeeze()
        {
            StartCoroutine(FreeeeezeCor());
        }

        IEnumerator FreeeeezeCor()
        {
            Player.Speed /= 2;
            yield return new WaitForSeconds(3);
            Player.Speed *= 2;
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}