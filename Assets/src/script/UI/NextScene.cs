using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NextScene : MonoBehaviour
{
    public void SceneChangeWithButton(string NextSceneName)
    {
        LoadingSceneManager.LoadScene(NextSceneName);    
    }


}
