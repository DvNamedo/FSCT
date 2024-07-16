using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goToJudge : MonoBehaviour
{
    public Transform judgePoint;
    public GameObject player;

    public void isFulfillingToken()
    {
        if(Center.instance.questionToken >= 4)
        {
            Debug.Log("transfort");
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = judgePoint.position;
            player.GetComponent<CharacterController>().enabled = true;
        }
        else
        {

        }
    }
}
