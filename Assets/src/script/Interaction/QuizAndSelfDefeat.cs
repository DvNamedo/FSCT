using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizAndSelfDefeat : MonoBehaviour
{
    public int continuousCount = 1;
    int count = 0;
    int maxCount = 0;

    private void Update()
    {
        foreach (var go in Center.instance.recentCorrectObject)
        {
            if (go == gameObject)
                count++;
            else
                count = 0;

            maxCount = Mathf.Max(maxCount, count);
        }

        count = 0;

        if(maxCount >= continuousCount)
        {
            Center.instance.questionToken++;
            Destroy(this.gameObject);
        }
    }
}
