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
        Debug.Log("We enabled the editor");
    }

    void OnDisable()
    {
        Debug.Log("We disabled the editor");
    }

    void OnDestroy()
    {
        Debug.Log("We destroyed the editor");
    }

    public override void OnInspectorGUI()
    {
        // MEMO - defatul inspector: base.OnInspectorGUI();
        iconTex =(Texture2D) Resources.Load("icons/tools");

        EditorGUILayout.Separator();    
        EditorGUILayout.LabelField("My Editor");

        GUIContent curContent = new GUIContent();
        curContent.image = iconTex;
        curContent.text = "My Int";
        curContent.tooltip = "My Tooltip for integer";
        targetScript.myInt = EditorGUILayout.IntField(curContent,targetScript.myInt);

        curContent.image = iconTex;
        curContent.text = "My Float";
        curContent.tooltip = "My Tooltip for float";
        targetScript.myFloat = EditorGUILayout.FloatField(curContent, targetScript.myFloat);
        
    }
    #endregion

    #region Utility Methods
    #endregion
}
