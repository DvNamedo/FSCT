using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class NextScene : MonoBehaviour
{
    public List<GameObject> unshowList; 

    public void SceneChangeWithButton(string NextSceneName)
    {
        foreach (var item in unshowList)
        {

            if (item.GetComponent<Image>() == null)
            {
                item.GetComponent<Text>().enabled = false;
            }
            else
            {
                item.GetComponent<Image>().enabled = false;
            }

            
        }
        StartCoroutine(mSceneChangeWithButton(NextSceneName));
    }

    public IEnumerator mSceneChangeWithButton(string NextSceneName)
    {
        Center.instance.step = Center.StartAnimatingPartition.btnClick;
        yield return new WaitUntil(() => Center.instance.step == Center.StartAnimatingPartition.blackBG_Show);

        Center.instance.cursorSetActive(false);
        LoadingSceneManager.LoadScene(NextSceneName);
    }


}
