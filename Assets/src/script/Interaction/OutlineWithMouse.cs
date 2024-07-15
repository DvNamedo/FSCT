using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OutlineWithMouse : MonoBehaviour
{
    public bool isShepheiding = false;

    public float clickReach = 1000f;
    public Camera playerCamera;


    [Range(0f, 1f)]
    public float[] strainColor;

    public UnityEvent onClickAtGameobjectEvent;

    private Outline mOutline;
    float r, g, b;

    float clearAlpha = 0f;

    float constant = 1f;

    bool mouseEntering;
    int R, G, B; // Used to make it look good at Array

    public void Awake()
    {
        if (gameObject.GetComponent<Outline>() == null)
        {
            Debug.LogWarning("Need to use \"Outline.cs\"");
            gameObject.AddComponent<Outline>();
        }

        mOutline = GetComponent<Outline>();

        r = mOutline.OutlineColor.r;
        g = mOutline.OutlineColor.g;
        b = mOutline.OutlineColor.b;

        mOutline.OutlineColor = new Color(r, g, b, 0f);

        R = 0;
        G = 1;
        B = 2;

    }

    public void Update()
    {
        if(isShepheiding)
            clearAlpha = (float)Math.Abs(Math.Sin(Time.time));

        if (mouseEntering)
            mOutline.OutlineColor = new Color(strainColor[R], strainColor[G], strainColor[B], constant);
        else
            mOutline.OutlineColor = new Color(r, g, b, clearAlpha * constant);
    }

    public void OnMouseOver()
    {
        mouseEntering = true;
        
        
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, clickReach))
        {
            mOutline.OutlineWidth = 10f;
        }
        else
        {
            mOutline.OutlineWidth = 5f;
        }

    }




    public void OnMouseExit()
    {
        mouseEntering = false;
        mOutline.OutlineWidth = 2.6f;


    }


    public void OnMouseDown()
    {
        if(onClickAtGameobjectEvent != null)
        {
            
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hit , clickReach))
            {
                onClickAtGameobjectEvent.Invoke();
            }
    
            
        }

    }
}