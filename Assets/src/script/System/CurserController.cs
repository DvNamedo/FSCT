using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurserController : MonoBehaviour
{
    public bool useCurser = true;

    public bool useInitialize = false;
    bool onActivate = false;

    // Start is called before the first frame update
    void Start()
    {
    //cursorSetActive(useCurser);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        if (useInitialize || onActivate)
            cursorSetActive(useCurser);
        else
            onActivate = true;
    }

    public static void cursorSetActive(bool activate)
    {
        if (activate == false)
        {
            Cursor.visible = false;                     //mouseCursor no see
            Cursor.lockState = CursorLockMode.Locked;   //mouseCursor fixed
        }
        else
        {
            Cursor.visible = true;                     //mouseCursor can see        
            Cursor.lockState = CursorLockMode.None;   //mouseCursor free
        }

    }

}
