
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private ParticleSystem system;
    public float rotationSpeedX;
    public float rotationSpeedY;
    public float rotationSpeedZ;

    // Start is called before the first frame update
    void Start()
    {
        system = GetComponent<ParticleSystem>();
        rotationSpeedX = Random.Range(45, 180);
        rotationSpeedY = Random.Range(45, 180);
        rotationSpeedZ = Random.Range(45, 180);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(rotationSpeedX, rotationSpeedY, rotationSpeedZ) * Time.deltaTime);
        if(!GetComponent<ParticleSystem>())
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GetComponent<ParticleSystem>().Play();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            GameData.Instance.coinCount++;
            ItemCount.Instance.ShowCount();
        }
    }
}
