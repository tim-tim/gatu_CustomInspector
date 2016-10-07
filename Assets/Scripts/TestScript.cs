using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour
{
    #region Public Variables
    public int myInt = 10;
    public float myFloat = 25.5f;
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

