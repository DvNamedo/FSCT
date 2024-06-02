
using UnityEngine;
using UnityEngine.SceneManagement;



public class ForceStart : MonoBehaviour
{


    static bool firstSceneLoadActivate = true; 

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void FirstLoad()
    {
        if(firstSceneLoadActivate)
            if (SceneManager.GetActiveScene().name.CompareTo("Title") != 0)

            {

                SceneManager.LoadScene("Title");

            }
    }

}