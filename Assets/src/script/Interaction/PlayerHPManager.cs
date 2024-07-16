using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPManager : MonoBehaviour
{
    public GameObject DeadOfSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Center.instance.isCorrectOnQuestion == false)
        {
            StartCoroutine(Center.instance.playSound(DeadOfSound));
            Center.instance.isCorrectOnQuestion = true;
        }
    }



}
