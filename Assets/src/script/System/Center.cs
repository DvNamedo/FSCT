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


    public bool isCorrectOnQuestion = true;

    public StartAnimatingPartition step = StartAnimatingPartition.none;
    public enum StartAnimatingPartition
    {
        none,
        btnClick,
        slicingEnd,
        blackBG_Show

    }




}
