using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class VideoManager : MonoBehaviour
{
    public RawImage ri;

    public List<GameObject> renderedVedioes;



    public void Awake()
    {
        foreach (var vedio in renderedVedioes)
        {
            if(vedio != null)
                vedio.GetComponent<VideoPlayer>().playOnAwake = false;
        }
    }

    public IEnumerator playVedio(GameObject temp)
    {
        Debug.Log("playVideo");

        gameObject.transform.GetChild(0).gameObject.SetActive(true);

        var vp = temp.GetComponent<VideoPlayer>();

        ri.texture = vp.targetTexture;

        //vp.playOnAwake = true;
        vp.Play();
        vp.time = 0;

        Debug.Log(vp.length);

        yield return new WaitUntil (() => vp.length - vp.time < 0.1f );

        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        vp.Pause();

    }

    public void playVedioVoid(GameObject temp)
    {
        StartCoroutine(playVedio(temp));
    }

}
