using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurserController : MonoBehaviour
{
    public bool useCurser = true;

    public bool useInitialize = false;
    bool onActivate = false;

    // Start is called before the first frame update
    void Start()
    {
    //cursorSetActive(useCurser);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        if (useInitialize || onActivate)
            Center.instance.cursorSetActive(useCurser);
        else
            onActivate = true;
    }



}
