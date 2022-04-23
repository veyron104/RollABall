using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BonusFinder))]
public class BonusFinderEditor : Editor
{
    BonusFinder itemCopy;

    public void OnEnable()
    {
        itemCopy = (BonusFinder)target;
    }

    public override void OnInspectorGUI()
    {
        GUI.enabled = false;
        EditorGUILayout.ObjectField("Editor script:", MonoScript.FromScriptableObject(this), typeof(BonusFinderEditor), false);
        EditorGUILayout.ObjectField("Script:", MonoScript.FromMonoBehaviour(itemCopy), typeof(BonusFinder), false);
        GUI.enabled = true;
        GUILayout.Space(10);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Game Manager", GUILayout.Width(80), GUILayout.Height(18));
        itemCopy.GM = (GameManager)EditorGUILayout.ObjectField(itemCopy.GM, typeof(GameManager), false);
        EditorGUILayout.EndHorizontal();


        if (itemCopy.GM.GoodBonuses.Count > 0) EditorGUILayout.LabelField($"На сцене {itemCopy.GM.GoodBonuses.Count} хороших бонусов.");
        else EditorGUILayout.LabelField("Хорошие бонусы на сцене отсутствуют!");

        if (itemCopy.GM.BadBonuses.Count > 0) EditorGUILayout.LabelField($"На сцене {itemCopy.GM.BadBonuses.Count} плохих бонусов.");
        else EditorGUILayout.LabelField("Плохие бонусы на сцене отсутствуют!");
        GUILayout.Space(10);

        if (GUILayout.Button("Обновить списки бонусов")) itemCopy.ComponentChecker();

        if (GUI.changed) EditorUtility.SetDirty(itemCopy);
    }
}