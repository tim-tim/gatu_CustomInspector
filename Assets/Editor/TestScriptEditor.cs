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

        EditorGUILayout.BeginHorizontal();
        GUILayout.Space(10);
        EditorGUILayout.BeginVertical();
        
        EditorGUILayout.LabelField("My Editor:");

        
        targetScript.myInt = EditorGUILayout.IntField(EditorUtils.BuildContent(
                    iconTex,
                    "My Int",
                    "My Tooltip for integer"
                    ),
                    targetScript.myInt);

        targetScript.myFloat = EditorGUILayout.FloatField(EditorUtils.BuildContent(
                    iconTex,
                    "My Float",
                    "My Tooltip for integer"
                    ),
                    targetScript.myFloat);       

        GUILayout.Space(10);

        if (GUILayout.Button(EditorUtils.BuildContent(
                    iconTex,
                    "Click Me",
                    "My Tooltip for button"
                    ),
                    GUILayout.Height(40)))
        {
            //Debug.Log("Button pressed");
            targetScript.MoveObject();
        }
        
        EditorGUILayout.EndVertical();
        GUILayout.Space(10);
        EditorGUILayout.EndHorizontal();

        if (GUI.changed)
        {
            Debug.Log("We changed the gui elements.");
        }

    }
    #endregion

    #region Utility Methods
    #endregion
}
