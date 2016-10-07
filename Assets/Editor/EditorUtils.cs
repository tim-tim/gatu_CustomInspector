using UnityEngine;
using UnityEditor;
using System.Collections;
/// <summary>
/// My custom utilities for custom editors and inspectors
/// </summary>
public static class EditorUtils
{
    public static GUIContent BuildContent(Texture2D icon, string label, string toolTip)
    {
        GUIContent curContent = new GUIContent();

        curContent.image = icon;
        curContent.text = label;
        curContent.tooltip = toolTip;

        return curContent;
    }

	
}
