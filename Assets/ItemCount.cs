using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCount : MonoBehaviour
{
    public static ItemCount Instance;
    public Transform camera;
    public float time = 1f;
    private float timePassed = 0f;
    private bool show = false;
    public TextMeshPro coinCount;
    public TextMeshPro fragCount;

    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        transform.LookAt(camera);

        coinCount.text = GameData.Instance.coinCount.ToString();
        fragCount.text = GameData.Instance.FragCount.ToString();

        if (show == true)
        {
            coinCount.enabled = true;
            fragCount.enabled = true;
            timePassed += Time.deltaTime;

            if(timePassed > time)
            {
                show = false;
                coinCount.enabled = false;
                fragCount.enabled = false;
            }
        }
    }

    public void ShowCount()
    {
        timePassed = 0;
        show = true;
    }
}
