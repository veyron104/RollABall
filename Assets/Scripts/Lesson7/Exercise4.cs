using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Lesson7
{
    public class Exercise4
    {
        Dictionary<string, int> _dictionary = new Dictionary<string, int>()
        {
            {"four", 4},
            {"two", 2},
            {"one", 1},
            {"three", 3}
        };
        public Exercise4()
        {
            var d = _dictionary.OrderBy(pair => pair.Value);

            foreach (var item in d)
            {
                Debug.Log($"{item.Key} - {item.Value}");
            }
        }
    }
}