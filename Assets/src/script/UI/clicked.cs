using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clicked : MonoBehaviour
{
    public bool isClick = false;

    private void Start()
    {
        isClick = false;
    }

    public void click()
    {
        isClick = true;
    }
}
