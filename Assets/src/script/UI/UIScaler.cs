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
                            //Default �ػ� ����
            float fixedAspectRatio = 16f / 9f;

            currentAspectRatio = (float)Screen.width / (float)Screen.height;



            //���� �ػ� ���� ������ �� �� ���
            if (currentAspectRatio > fixedAspectRatio)
            {
                scaler.matchWidthOrHeight = 1;
                Debug.Log("����");
            }
            //���� �ػ��� ���� ������ �� �� ���
        
            if (currentAspectRatio < fixedAspectRatio)
            {
                scaler.matchWidthOrHeight = 0;
                Debug.Log("����");
            }
        }



    }
}
