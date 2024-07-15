using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockerManager : MonoBehaviour
{
    public float moveSpeed;

    bool isOpen = false;

    private void Awake()
    {
    }

    private void Start()
    {

    }

    public void doorManage()
    {
        if (isOpen) // door open
        {

            isOpen = false;
            Debug.Log("열림");

        }
        else // door close
        {

            isOpen = true;
            Debug.Log("닫힘");
        }
    }

    private void Update()
    {
        if (transform.rotation.eulerAngles.y < 0.1f)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0f, transform.rotation.eulerAngles.z);
        }

        if (isOpen)
        {
            if (transform.rotation.eulerAngles.y < 90f)
            {
                transform.RotateAround(transform.GetChild(0).position, Vector3.up, moveSpeed * Time.deltaTime);
                // 회전 각도가 90도를 초과하지 않도록 제한
                if (transform.rotation.eulerAngles.y > 90f)
                {
                    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 90f, transform.rotation.eulerAngles.z);
                }
            }



        }
        else
        {
            if (transform.rotation.eulerAngles.y > 0.5f) // 이 값을 조정하여 0에 가까운 값을 설정합니다
            {
                transform.RotateAround(transform.GetChild(0).position, Vector3.up, -moveSpeed * Time.deltaTime);
                // 회전 각도가 0도 미만이 되지 않도록 제한
                if (transform.rotation.eulerAngles.y < 0.5f) // 이 값을 조정하여 0에 가까운 값을 설정합니다
                {
                    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0f, transform.rotation.eulerAngles.z);
                }
            }


        }   




    }
}
