using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFader : MonoBehaviour
{
    public GameObject thisObject;

    public float offset;

    public bool initalFade;
    public bool isDe;

    public bool CepheidFabe;
    public float frequency;
    public float Amplitude;


    int frame;

    private void Awake()
    {
        frame = 0;
    }

    private void OnEnable()
    {
        Debug.Log("work!");
        if (initalFade)
        {
            if (!isDe)
            {
                StartCoroutine(DeFading());

                
            }
            else
            {
                StartCoroutine(Fading());

                
            }
        }
    }

    private void FixedUpdate()
    {
        if (CepheidFabe)
        {
            float sinValue = Amplitude * Mathf.Sin(2 * Mathf.PI * frequency * frame);
            
            thisObject.GetComponent<Image>().color = new Color(0,0,0,(offset + sinValue) / 255f);
            frame++;
            if(frame > 20 / frequency)
            {
                frame = 0;
            }

        }
    }


    IEnumerator DeFading()
    {
        yield return new WaitWhile(() => { 
            float cosValue = Amplitude * Mathf.Cos(2 * Mathf.PI * frequency * frame);
            thisObject.GetComponent<Image>().color = new Color(0, 0, 0, (offset + cosValue) / 255f);

            Debug.Log($"defading:{frame}");
            frame++;
            return frame < 1 / (4 * frequency);
        });
        frame = 0;
    }

    IEnumerator Fading()
    {
        yield return new WaitWhile(() => {
            float sinValue = Amplitude * Mathf.Sin(2 * Mathf.PI * frequency * frame);
            thisObject.GetComponent<Image>().color = new Color(0, 0, 0, (offset + sinValue) / 255f);

            frame++;
            return frame < 1 / (4 * frequency);
        });
        frame = 0;
    }

}
