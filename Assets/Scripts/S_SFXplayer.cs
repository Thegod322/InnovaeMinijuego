using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SFXplayer : MonoBehaviour
{
    public AudioClip explosionSFX;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = explosionSFX;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
