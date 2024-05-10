using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Center : MonoBehaviour
{
    private static Center mInstance = null;
    public static Center instance
    {
        get
        {
            if(mInstance == null)
            {
                return null;
            }
            return mInstance;
        }
        set
        {

        }
    }

    private void Awake()
    {
        if (mInstance == null)
        {
            mInstance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    public int testValue = 0;
    private float mTestF = 0f;
    public float testF
    {
        get
        {
            return mTestF;
        }
        set
        {
            if(value < 2.5f)
            {
                mTestF = value;
            }
            else
            {
                mTestF = 2.5f;
            }
        }
    }

    public void testFunction()
    {
        Debug.Log("h");
    }

    public void CursorSetActive(bool activate)
    {
        if(activate == false)
        {
            Cursor.visible = false;                     //mouseCursor no see
            Cursor.lockState = CursorLockMode.Locked;   //mouseCursor fixed
        }
        else
        {
            Cursor.visible = true;                     //mouseCursor can see        
            Cursor.lockState = CursorLockMode.None;   //mouseCursor free
        }

    }

}
