using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum FoodType { Water, Bred, Milk, Meat, Vegetables, Fruits, Berry, Greens };
public class WindowItems : EditorWindow
{
    FoodType type;
    string _nameObject = "Hello World!";
    int _step;
    float _sliderStepper;
    float _tempSlider = 0;
    bool _toggle = true;

    void OnGUI()
    {
        GUILayout.Label(_nameObject, EditorStyles.boldLabel);


        GUILayout.BeginHorizontal();
        EditorGUILayout.TextArea(_nameObject, GUILayout.Width(100), GUILayout.Height(18));
        GUILayout.BeginVertical();
        if (GUILayout.Button("Обновить списки бонусов", GUILayout.Width(250), GUILayout.Height(18))) MenuItems.Check();
        GUILayout.BeginHorizontal();
        EditorGUILayout.TextField(_nameObject, GUILayout.Width(80), GUILayout.Height(36));
        GUILayout.BeginVertical();
        EditorGUILayout.TextField(_nameObject, GUILayout.Width(150), GUILayout.Height(18));
        EditorGUILayout.TextField(_nameObject + _nameObject+ _nameObject+ _nameObject, GUILayout.Width(150), GUILayout.Height(36));
        GUILayout.Label(_nameObject, GUILayout.Width(80), GUILayout.Height(18));
        GUILayout.BeginHorizontal();
        GUILayout.Label("Слайдеры", GUILayout.Width(80), GUILayout.Height(36));
        GUILayout.BeginVertical();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Шаг слайдера", GUILayout.Width(50));
        _step = (int)EditorGUILayout.Slider(_step, 1, 10, GUILayout.Width(250));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Slider", GUILayout.Width(50));
        _tempSlider = EditorGUILayout.Slider(_sliderStepper, 0, 50, GUILayout.Width(250));
        _sliderStepper = _tempSlider - _tempSlider % _step;
        GUILayout.EndHorizontal();
        GUILayout.Label("Это к вопросу о шаге для слайдера", GUILayout.Width(250));
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
        GUI.enabled = false;
        GUILayout.TextArea("Затык по реализации атрибута. Не понимаю что требуется. Путь к какому объекту нужно найти и куда вывести? Атрибуты же применяются к какой-то переменной, ну типа показать или скрыть в инспекторе. И какой путь к какому объекту нужно найти, типа объект есть на сцене, значит нужно путь к этой сцене показать, или путь к скрипту, или путь к префабу?", GUILayout.Width(450), GUILayout.Height(85));
        GUI.enabled = true;

        GUILayout.Label("Затык по реализации атрибута. Не понимаю что требуется. Путь к какому объекту нужно \nнайти и куда вывести? Атрибуты же применяются к какой-то переменной, ну типа показать \nили скрыть в инспекторе. И какой путь к какому объекту нужно найти, типа объект есть на \nсцене, значит нужно путь к этой сцене показать, или путь к скрипту, или путь к префабу?", GUILayout.Width(550), GUILayout.Height(85));

        GUILayout.BeginHorizontal();
        _toggle = GUILayout.Toggle(_toggle, "галка", GUILayout.Width(80), GUILayout.Height(18));
        if (_toggle)
        {
            if (GUILayout.Button("Обновить списки бонусов", GUILayout.Width(250), GUILayout.Height(18))) MenuItems.Check();
        }
        else
        {
            EditorGUILayout.LabelField("Выбрать тип продукта", GUILayout.Width(150));
            type = (FoodType)EditorGUILayout.EnumPopup(type, GUILayout.Width(80));

            switch (type)
            {
                case FoodType.Water:
                    EditorGUILayout.LabelField($"{type.ToString()} + 10", GUILayout.Width(150));
                    break;
                case FoodType.Bred:
                case FoodType.Milk:
                    EditorGUILayout.LabelField($"{type.ToString()} + 20", GUILayout.Width(150));
                    break;
                case FoodType.Meat:
                case FoodType.Vegetables:
                case FoodType.Fruits:
                    EditorGUILayout.LabelField($"{type.ToString()} + 30", GUILayout.Width(150));
                    break;
                case FoodType.Berry:
                case FoodType.Greens:
                    EditorGUILayout.LabelField($"{type.ToString()} + 40", GUILayout.Width(150));
                    break;
            }
        }
        EditorGUILayout.EndHorizontal();
    }

    [MenuItem("RollABall/Окно обновления бонусов")]
    public static void CheckerWindow()
    {
        EditorWindow.GetWindow(typeof(WindowItems), false, "Окно_обновления_бонусов");
    }
}