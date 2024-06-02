using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startFadeController : MonoBehaviour
{
    public GameObject FadingObject;
    public GameObject Sound;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fadingControl());
    }

    IEnumerator fadingControl()
    {
        yield return new WaitUntil(() => Center.instance.step == Center.StartAnimatingPartition.btnClick);

        FadingObject.SetActive(true);
        var source = Instantiate(Sound);
        source.SetActive(true);

        yield return new WaitWhile(() => source.GetComponent<AudioSource>().isPlaying);
        Destroy(source);
        Debug.Log("家府 犁积 场");
        yield return new WaitUntil(() => FadingObject.GetComponent<Image>().color.a > 0.95f);
        Center.instance.step = Center.StartAnimatingPartition.blackBG_Show;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
