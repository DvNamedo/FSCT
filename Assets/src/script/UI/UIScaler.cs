using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScaler : MonoBehaviour
{
    public GameObject thisCanvas;
    CanvasScaler scaler;

    bool isChanged = true;

    private float _currentAspectRatio;

    public float currentAspectRatio
    {
        get => _currentAspectRatio;
        set
        {
            if (_currentAspectRatio != value)
            {
                _currentAspectRatio = value;
                isChanged = true;
            }
        }
    }


    private void Awake()
    {
        scaler = thisCanvas.GetComponent<CanvasScaler>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isChanged) 
        {
            isChanged = false;
                            //Default 해상도 비율
            float fixedAspectRatio = 16f / 9f;

            currentAspectRatio = (float)Screen.width / (float)Screen.height;



            //현재 해상도 가로 비율이 더 길 경우
            if (currentAspectRatio > fixedAspectRatio)
            {
                scaler.matchWidthOrHeight = 1;
                Debug.Log("가로");
            }
            //현재 해상도의 세로 비율이 더 길 경우
        
            if (currentAspectRatio < fixedAspectRatio)
            {
                scaler.matchWidthOrHeight = 0;
                Debug.Log("세로");
            }
        }



    }
}
