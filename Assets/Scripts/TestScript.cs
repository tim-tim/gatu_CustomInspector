using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestScript : MonoBehaviour
{
    #region Public Variables
    public bool showList = false;

    public int myInt = 10;
    public float myFloat = 25.5f;

    public List<string> myStringList = new List<string>();
    #endregion

    #region Private Variables
    #endregion

    #region Main Methods
    #endregion

    #region Utility Methods
    public void MoveObject()
    {
        transform.position += new Vector3(0f, 1f, 0f);
    }
    #endregion
}

