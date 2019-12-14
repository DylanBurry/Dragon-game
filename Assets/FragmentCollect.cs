
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class FragmentCollect : MonoBehaviour
{
    private ParticleSystem system;
    public bool shrinking;
    public float riseSpeed = 0.15f;
    public float shrinkSpeed = 0.05f;
    public float spinSpeed = 0.05f;
    public float spinAccel = 2f;
    //public bool hasBeenCollected;

    // Start is called before the first frame update
    void Start()
    {
        system = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GetComponent<ParticleSystem>())
        {
            //Destroy(this.gameObject);
        }

        if (shrinking == true)
        {
            spinSpeed += spinAccel;
            transform.Rotate(0, 0, spinSpeed);
            transform.localPosition += new Vector3(0, riseSpeed, 0);
            transform.localScale -= new Vector3(shrinkSpeed, shrinkSpeed, shrinkSpeed);
            if (transform.localScale.x <= 0 && !GetComponent<ParticleSystem>().isPlaying)
            {
                GetComponent<MeshRenderer>().enabled = false;
                shrinking = false;
                transform.localScale = new Vector3(1f, 1f, 1f);
                //GetComponent<ParticleSystem>().Play();
                VisualEffect vfx = GetComponentInChildren<VisualEffect>();
                vfx.enabled = true;
                vfx.Play();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            shrinking = true;
            GetComponent<Collider>().enabled = false;
            Debug.Log(other.tag);
            GameData.Instance.FragCount++;
            ItemCount.Instance.ShowCount();

            SaveManager.Instance.SaveGame();
        }
    }
}
