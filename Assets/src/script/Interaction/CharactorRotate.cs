using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorRotate : MonoBehaviour
{
    public GameObject virtical;
    public float Xspeed = 1f;
    public float weight = 1f;
    public float t = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, Input.GetAxis("Mouse X") * Xspeed, 0f, Space.World);
        transform.Rotate(-Input.GetAxis("Mouse Y") * Xspeed, 0f, 0f);
       

        //virtical.transform.position = new Vector3(0, weight * Mathf.Tan(t * Input.GetAxis("Mouse Y")), 1);
        
        //
        //virtical.transform.Translate()
    }
}
