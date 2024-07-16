using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endSystem : MonoBehaviour
{
    public GameObject endButton;

    bool isSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isSpawned && Center.instance.questionToken >= 5)
        {
            endButton.SetActive(true);
            isSpawned = true;
        }
    }
}
