using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public GameObject rewards;
    public float pressing;
    public float pressSpeed;
    public float bottomPress;
    public bool isPressed;

    void OnTriggerEnter(Collider other)
    {
        isPressed = true;
    }

    private void Update()
    {
        if (isPressed == true && pressing <= bottomPress)
        {
            rewards.SetActive(true);
            pressing += pressSpeed;
            transform.Translate(new Vector3(0, -pressing, 0));
        }
    }
}
