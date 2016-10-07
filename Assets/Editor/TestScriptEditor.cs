using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(TestScript))]
public class TestScriptEditor : Editor
{
    #region Public Variables
    public TestScript targetScript;    
    #endregion

    #region Private Variables
    #endregion

    #region Main Methods
    void OnEnable()
    {

    }
    #endregion

    #region Utility Methods
    #endregion
}
