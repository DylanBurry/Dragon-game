using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroText : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (GameData.Instance.Intro == false)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 0;
        if (Player.player.jumpButton)
        {
            GameData.Instance.Intro = false;
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
    }
}
