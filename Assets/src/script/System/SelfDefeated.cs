using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDefeated : MonoBehaviour
{
    public void killmeAfterTime(float time)
    {
        Destroy(this.gameObject, time);
    }
}
