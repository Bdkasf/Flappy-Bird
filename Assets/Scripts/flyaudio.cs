using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Audio : MonoBehaviour
{
    public AudioSource audioSource;
    public Gamemanager gmr;

    void Start()
    {
        GetComponent<Gamemanager>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(gmr.isgameReady == true)
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.Play();
        }
    }
}
