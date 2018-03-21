using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCreditsAudio : MonoBehaviour {

    public GameObject Sphere;
    AudioSource endCredit;
    VideoController playing;

    private void Start()
    {
        playing = Sphere.GetComponent<VideoController>();
        endCredit = gameObject.GetComponent<AudioSource>();
    }

    void Update () {
        if (!playing.audioSource.isPlaying && playing.finished)
        {
            endCredit.Play();
        }
	}
}
