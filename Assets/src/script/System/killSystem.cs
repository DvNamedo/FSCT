using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killSystem : MonoBehaviour
{
    public void Kill()
    {
        Center.instance.playerHP = -1;
    }
}
