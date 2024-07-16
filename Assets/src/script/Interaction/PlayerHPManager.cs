using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPManager : MonoBehaviour
{
    public GameObject DeadOfSound;
    public float quizHealth;
    public float fearHealth;

    public List<GameObject> hpDeclinement;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Center.instance.isCorrectOnQuestion == false)
        {
            Center.instance.playerHP -= quizHealth;
            StartCoroutine(Center.instance.playSound(DeadOfSound));
            Center.instance.isCorrectOnQuestion = true;
        }

        foreach (var go in hpDeclinement)
        {
            if(Vector3.Distance( go.transform.position, gameObject.transform.position) < 0.8f)
            {
                Center.instance.playerHP -= fearHealth;
            }
        }

    }
}