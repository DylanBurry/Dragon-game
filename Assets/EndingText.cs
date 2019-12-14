using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.Instance.FragCount == 4)
        {
            gameObject.SetActive(true);
            if (this.enabled == true) 
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
            
            if (Player.player.jumpButton)
            {
                Time.timeScale = 1;
                gameObject.SetActive(false);
            }
        }

    }
}
