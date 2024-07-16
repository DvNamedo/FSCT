using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameoverTextManager : MonoBehaviour
{
    public GameObject GameoverTextPanel;
    public List<GameObject> additionalHides;

    // Start is called before the first frame update
    void Start()
    {
        GameoverTextPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Center.instance.playerHP <= 0)
        {
            Center.instance.cursorSetActive(true);

            foreach (var go in additionalHides)
            {
                go.SetActive(false);
            }

            GameoverTextPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
