using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson7
{
    public class Exercise3
    {
        List<int> _numberList = new List<int>();
        Dictionary<int, int> _numberCounter = new Dictionary<int, int>();

        ArrayList _arList = new ArrayList();
        int[] _arListCounter;
        public Exercise3()
        {
            int randomRange = 5;
            int listSize = 10;
            string tempList = "";

            #region Generator
            for (int i = 0; i < listSize; i++)
            {
                _numberList.Add(Random.Range(0, randomRange));
                if (_numberCounter.ContainsKey(_numberList[i])) _numberCounter[_numberList[i]]++;
                else _numberCounter.Add(_numberList[i], 1);
                tempList += _numberList[i] + "  ";
            }
            #endregion
            Debug.Log("Исходный массив\n" + tempList);
            for (int i = 0; i < randomRange; i++)
            {
                if (_numberCounter.ContainsKey(i)) Debug.Log($"число {i} встречается {_numberCounter[i]} раз");
            }
            // мде, оказывается обобщённая коллекция это просто коллекция какого-то типа, а не ЭррайЛист... Тогда в чём разница "а" и "b" задания ???
            #region Generator2
            listSize = 10;
            tempList = "";
            for (int i = 0; i < listSize; i++)
            {
                int type = Random.Range(0, 3);
                switch (type)
                {
                    case 0: // int
                        _arList.Add(Random.Range(0, randomRange));
                        break;
                    case 1: // float
                        _arList.Add(0.8f);
                        break;
                    case 2: // string
                        _arList.Add("a" + Random.Range(0, randomRange).ToString());
                        break;
                }
                tempList += _arList[i] + "  ";
            }
            _arListCounter = new int[listSize];
            #endregion
            Debug.Log("Второй исходный массив\n" + tempList);
            for (int i = 0; i < listSize; i++)
            {
                for (int j = 0; j < listSize; j++)
                {
                    if (_arList[i].Equals(_arList[j])) _arListCounter[i]++;
                }
            }
            for (int i = 0; i < listSize; i++)
            {
                Debug.Log($"Элемент {_arList[i]} встречается {_arListCounter[i]} раз");
            }
        }
    }
}