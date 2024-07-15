using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public float staminaPlus = 1f;
    public float hpPlus = 1f;
    public int fearPlus = 1;

    public void stamina()
    {
        Center.instance.playerStamina += staminaPlus;

        Destroy(this.gameObject);
    }

    public void hp()
    {
        Center.instance.playerHP += hpPlus;

        Destroy(this.gameObject);
    }

    public void fear()
    {
        Center.instance.playerFear += fearPlus;

        Destroy(this.gameObject);
    }

}
