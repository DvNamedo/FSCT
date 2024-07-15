using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaInteract : MonoBehaviour
{
    public float playerStaminaSprintReduceSpeed = 100.0f;
    public float playerStaminaJumpReduceSpeed = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StaminaRegen());
        StartCoroutine(staminaTimerManage());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Center.instance.staminaTimer = 0f;
            Center.instance.playerStamina -= playerStaminaJumpReduceSpeed;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Center.instance.staminaTimer = 0f;
            Center.instance.playerStamina -= playerStaminaSprintReduceSpeed;
        }
    }
    IEnumerator staminaTimerManage()
    {
        while (true)
        {
            yield return new WaitUntil(() => Center.instance.staminaTimer < Center.instance.staminaTimerLimit);

            yield return new WaitForSeconds(0.01f);
            Center.instance.staminaTimer += 0.01f;


        }


    }

    IEnumerator StaminaRegen()
    {
        while (true)
        {
            yield return new WaitUntil(() => Center.instance.staminaTimer >= Center.instance.staminaTimerLimit);

            yield return new WaitForSeconds(0.01f);
            Center.instance.playerStamina += Center.instance.staminaRegenSpeed;

        }
    }
}
