using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(TestScript))]
public class TestScriptEditor : Editor
{
    #region Public Variables    
    #endregion

    #region Private Variables
    TestScript targetScript;
    Texture2D iconTex;
    #endregion

    #region Main Methods
    // 1) в "режиме" редактора функция OnEnable вызывается при клике по объекту, т.е. при его активации
    void OnEnable()
    {
        // target - это поле, унаследованное от класса Editor, которое хранит в себе ссылку на "активированный" объект
        // возвращает Object, поэтому используется каст до нужного класса("изъятия" компоненты)
        targetScript = (TestScript)target;
    }

    public override void OnInspectorGUI()
    {
        // MEMO - defatul inspector: base.OnInspectorGUI();
        iconTex =(Texture2D) Resources.Load("icons/tools");

        GUIContent curContent = new GUIContent();
        curContent.image = iconTex;
        curContent.text = "My Int";
        curContent.tooltip = "My Tooltip";


        EditorGUILayout.Separator();    
        EditorGUILayout.LabelField("My Editor");

        targetScript.myInt = EditorGUILayout.IntField(curContent,targetScript.myInt);

        curContent.text = "My Float";
        targetScript.myFloat = EditorGUILayout.FloatField(curContent, targetScript.myFloat);
        
    }
    #endregion

    #region Utility Methods
    #endregion
}
