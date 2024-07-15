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
            Debug.Log("����");

        }
        else // door close
        {

            isOpen = true;
            Debug.Log("����");
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
                // ȸ�� ������ 90���� �ʰ����� �ʵ��� ����
                if (transform.rotation.eulerAngles.y > 90f)
                {
                    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 90f, transform.rotation.eulerAngles.z);
                }
            }



        }
        else
        {
            if (transform.rotation.eulerAngles.y > 0.5f) // �� ���� �����Ͽ� 0�� ����� ���� �����մϴ�
            {
                transform.RotateAround(transform.GetChild(0).position, Vector3.up, -moveSpeed * Time.deltaTime);
                // ȸ�� ������ 0�� �̸��� ���� �ʵ��� ����
                if (transform.rotation.eulerAngles.y < 0.5f) // �� ���� �����Ͽ� 0�� ����� ���� �����մϴ�
                {
                    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0f, transform.rotation.eulerAngles.z);
                }
            }


        }   




    }
}
