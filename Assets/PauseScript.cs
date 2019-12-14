using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    void Update()
    {
        if (Player.player.pauseButton)
        {
            if (gameObject.activeSelf == true)
            {
                gameObject.SetActive(false);
            }
        }

        if (gameObject.activeSelf == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
