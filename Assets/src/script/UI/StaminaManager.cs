using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StaminaManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Image StaminaBar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StaminaBar.fillAmount = Center.instance.playerStamina / Center.instance.playerMaxStamina;
    }
       
}
