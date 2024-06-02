using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPManager : MonoBehaviour
{
    public GameObject DeadOfSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Center.instance.isCorrectOnQuestion == false)
        {
            StartCoroutine(playSound(DeadOfSound));
            Center.instance.isCorrectOnQuestion = true;
        }
    }

    public IEnumerator playSound(GameObject source)
    {
        var sound = Instantiate(source);
        sound.SetActive(true);

        yield return new WaitWhile(() => sound.GetComponent<AudioSource>().isPlaying);
        Destroy(sound);
    }

}
