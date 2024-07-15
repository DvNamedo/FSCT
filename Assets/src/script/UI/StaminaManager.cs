using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaManager : MonoBehaviour
{
    public Image StaminaBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StaminaBar.fillAmount = Center.instance.playerStamina / Center.instance.playerMaxStamina;
    }
}
