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


    public StartAnimatingPartition step = StartAnimatingPartition.none;
    public enum StartAnimatingPartition
    {
        none,
        btnClick,
        slicingEnd,
        blackBG_Show

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
