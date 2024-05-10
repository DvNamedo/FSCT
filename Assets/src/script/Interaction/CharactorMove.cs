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
    //[SerializeField] Vector3 target;
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
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * weight * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * weight * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * weight * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * weight * Time.deltaTime);
        }


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
