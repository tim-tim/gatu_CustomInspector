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
    string curString = "Add a new string...";
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

        GUILayout.Space(10);        

        targetScript.showList = EditorGUILayout.Foldout(targetScript.showList, "Show List:");
        if (targetScript.showList)
        {
            if (targetScript.myStringList != null)
            {
                if (targetScript.myStringList.Count > 0)
                {
                    for (int i = 0; i < targetScript.myStringList.Count; i++)
                    {
                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.TextField("String_0" + i, targetScript.myStringList[i]);
                        if (GUILayout.Button("-", GUILayout.Width(20)))
                        {
                            if (targetScript.myStringList[i] != null)
                            {
                                if (EditorUtility.DisplayDialog("Warning:", "Remove an item?", "OK"))
                                {
                                    targetScript.myStringList.RemoveAt(i);
                                }
                            }
                            
                        }
                        EditorGUILayout.EndHorizontal();
                    }
                }
                else
                {
                    EditorGUILayout.LabelField("No string entered into list...");
                }

                GUILayout.Space(15);

                curString = EditorGUILayout.TextField("String to Add: ", curString);
                if(GUILayout.Button("Add String", GUILayout.Height(40)))
                {
                    if(curString != "Add a new string..." && curString != "")
                    {
                        targetScript.myStringList.Add(curString);
                        curString = "Add a new string...";
                    }
                    else
                    {
                        EditorUtility.DisplayDialog("Editor Message:", "Please enter a valid string...", "OK");
                    }
                }
            }
            else
            {
                EditorGUILayout.LabelField("List is null");
            }            
            
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
