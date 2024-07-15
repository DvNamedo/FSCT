using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicingDoor : MonoBehaviour
{
    public Vector3 openedPosition;
    public float moveSpeed;
    Vector3 closedPosition;

    bool isOpen = false;

    private void Awake()
    {
    }

    private void Start()
    {
        //openedPosition = new Vector3(11.63f, 5.04f, -5.82f);
        closedPosition = transform.position;
    }

    public void doorManage()
    {
        if (isOpen) // door open
        {

            isOpen = false;
            Debug.Log("¿­¸²");

        }
        else // door close
        {

            isOpen = true;
            Debug.Log("´ÝÈû");
        }
    }

    private void Update()
    {
        if (isOpen)
        {
            //transform.position = openedPosition;
            transform.position = Vector3.Lerp(transform.position, openedPosition, moveSpeed);
        }
        else
        {
            //transform.position = closedPosition;
            transform.position = Vector3.Lerp(transform.position, closedPosition, moveSpeed);
        }

    }



}
