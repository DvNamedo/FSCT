using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSlicing : MonoBehaviour
{
    public float changeInterval = 0.5f;
    public int sliceAmount = 5;
    public float sliceWeight = 1;
    public float blackTime = 0.5f;
    public Image bg;
    public Sprite black;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(slicingImage());
    }

    IEnumerator slicingImage()
    {
        yield return new WaitUntil(() => Center.instance.step == Center.StartAnimatingPartition.btnClick);

        Debug.Log("okl");

        var count = 0;
        while(count < sliceAmount)
        {
            count++;
            Debug.Log("ok");
            bg.pixelsPerUnitMultiplier += sliceWeight;
            yield return new WaitForSeconds(changeInterval);
        }

        Center.instance.step = Center.StartAnimatingPartition.slicingEnd;
        bg.pixelsPerUnitMultiplier = 1f;
        bg.sprite = black;
        yield return new WaitForSeconds(blackTime);
        Center.instance.step = Center.StartAnimatingPartition.blackBG_Show;

        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
