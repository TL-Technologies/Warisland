using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mscctr : MonoBehaviour
{
    public AudioClip[] a;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().clip = a[Random.Range(0, a.Length)];
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(UiManager.instance.fight)
        {
            GetComponent<AudioSource>().mute = true;
        }
        else
        {
            GetComponent<AudioSource>().mute = false;
        }
    }
}
