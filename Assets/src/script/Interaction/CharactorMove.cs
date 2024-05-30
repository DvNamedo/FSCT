using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharactorMove : MonoBehaviour
{
    public float weight = 1.0f; // in the future, this variable can be transferred to Center Class, so that it is interacted with UI system 
    public float jumpWeight = 1f;
    public float jumpDelay = 0.2f;
    public int duration = 10;
    [SerializeField]
    GameObject center;
    Rigidbody rigid;
    bool OnGround = false;

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var dir = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            dir = Vector3.forward;

        }

        if (Input.GetKey(KeyCode.S))
        {
            dir = Vector3.back;

        }

        if (Input.GetKey(KeyCode.A))
        {
            dir = Vector3.left;

        }

        if (Input.GetKey(KeyCode.D))
        {
            dir = Vector3.right;

        }

        rigid.MovePosition(rigid.position + center.transform.TransformDirection(dir).normalized * Time.deltaTime * weight);



        if (Input.GetKeyDown(KeyCode.Space) && OnGround)
        {

            StartCoroutine(Jump(jumpWeight, jumpDelay, duration));
        }



    }

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.CompareTag("Ground"))
        {

            OnGround = true;
        }




    }



    IEnumerator Jump(float weight, float Delay, int Duration)
    {

        OnGround = false;
        yield return new WaitForSeconds(Delay);
        rigid.AddForce(Vector3.up * weight, ForceMode.Impulse);
    }

}
