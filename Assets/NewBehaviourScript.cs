using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    int i = 0;

    void Start()
    {

        StartCoroutine(ScoreUp());
        Debug.Log("실행 됐냐?");
    }

    public IEnumerator ScoreUp()
    {

        while (true)
        {
            Debug.Log("실행");
            i++;

            yield return new WaitForSeconds(0.5f);

        }

    }
}
