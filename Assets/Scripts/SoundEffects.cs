using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioClip ballSound;
    private AudioSource ballAudio;

    // Start is called before the first frame update
    void Start()
    {
        ballAudio = GetComponent<AudioSource>();
    }

    // Play a sound when a ball bounces off a peg
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Peg"))
        {
            ballAudio.PlayOneShot(ballSound, 1.0f);
        }
    }
}
