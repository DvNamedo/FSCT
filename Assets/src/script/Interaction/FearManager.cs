using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.UI;

public class FearManager : MonoBehaviour
{
    public float weight = 0.8f;


    float initMoveSpeed;
    float initSprnSpeed;

    private void Awake()
    {
        initMoveSpeed = gameObject.GetComponent<ThirdPersonController>().MoveSpeed;
        initSprnSpeed = gameObject.GetComponent<ThirdPersonController>().SprintSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Center.instance.playerFear = (Center.instance.isSeen ? 2 : 0)
            + (Center.instance.playerStamina / Center.instance.playerMaxStamina > 0.3f ? 1 : 0)
            + Mathf.RoundToInt((Center.instance.playerHP / Center.instance.playerMaxHP) * 2);

        gameObject.GetComponent<ThirdPersonController>().MoveSpeed = initMoveSpeed * Mathf.Clamp((5 - Center.instance.playerFear) * (1- weight) * 0.2f + weight, weight, 1f);
        gameObject.GetComponent<ThirdPersonController>().SprintSpeed = initSprnSpeed * Mathf.Clamp((5 - Center.instance.playerFear) * (1 - weight) * 0.2f + weight, weight, 1f);

        //float value = (5 - Center.instance.playerFear) * 0.5f;
        //fearPaper.color = Center.instance.playerFear >= 3 ? new Color(value, value, value, 1) : new Color(1, 1, 1, 0);

    }
}
