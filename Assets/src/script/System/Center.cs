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
    public float staminaTimer = 2.0f;
    public float staminaTimerLimit = 2.0f;
    public float staminaRegenSpeed = 1.0f;
    public float playerMaxHP = 100.0f;
    private float _playerHP = 100.0f;

    public float playerHP
    {
        get
        {
            return _playerHP;
        }
        set
        {
            if (value < 0)
            {
                _playerHP = 0;
            }
            else if (value > playerMaxHP)
            {
                _playerHP = playerMaxHP;
            }
            else
            {
                _playerHP = value;

            }
        }
    }

    public float playerMaxStamina = 100.0f;
    private float _playerStamina = 100.0f;

    public float playerStamina
    {
        get
        {
            return _playerStamina;
        }
        set
        {
            if (value < 0)
            {
                _playerStamina = 0;
            }
            else if (value > playerMaxStamina)
            {
                _playerStamina = playerMaxStamina;
            }
            else
            {
                _playerStamina = value;

            }
        }
    }

    public int playerMaxFear = 5;
    private int _playerFear = 0;

    public int playerFear
    {
        get
        {
            return _playerFear;
        }
        set
        {
            if (value < 0)
            {
                _playerFear = 0;
            }
            else if (value > playerMaxFear)
            {
                _playerStamina = playerMaxFear;
            }
            else
            {
                _playerFear = value;

            }
        }
    }

    public void cursorSetActive(bool activate)
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

    public StartAnimatingPartition step = StartAnimatingPartition.none;
    public enum StartAnimatingPartition
    {
        none,
        btnClick,
        FadingEnd,
        blackBG_Show
    }




}
