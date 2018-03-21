using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour {

    private UnityEngine.Video.VideoPlayer videoPlayer;

    public GameObject Button;

 
    public AudioSource audioSource;

    private AudioSource videoAudio;

    public bool finished = false;


    void Start()
    {
        videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        videoAudio = GetComponent<AudioSource>();

        if (videoPlayer.clip != null)
        {
            videoPlayer.EnableAudioTrack(0, true);
            videoPlayer.SetTargetAudioSource(0, audioSource);
        }
    }

    //Check if input keys have been pressed and call methods accordingly.
    public void PlayVideo()
    {
        if (videoPlayer.isPrepared)
        {
            audioSource.Play();
            videoPlayer.Play();
            videoAudio.Play();
            finished = true;
            //audioSource.Play();
        }
        else
        {
            Debug.Log("The video is still loading...");
        }
    }

    public void PauseVideo()
    {
        videoPlayer.Pause();
        audioSource.Pause();
        videoAudio.Pause();
    }

    public void Restart()
    {
        videoAudio.Play();
        videoPlayer.frame = 0;
        audioSource.Play();
        Button.SetActive(false);
        finished = false;
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void Update()
    {
        if (!audioSource.isPlaying && finished)
        {
            Button.SetActive(true);
        }

        if (videoPlayer.isPrepared)
        {
            Debug.Log("Now you can play the video!");
        }
    }
}
