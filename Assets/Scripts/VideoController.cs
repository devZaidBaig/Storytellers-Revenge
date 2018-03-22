using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour {

    private UnityEngine.Video.VideoPlayer videoPlayer;

    public GameObject Button;

 
    public GvrAudioSource audioSource;

    private AudioSource videoAudio;
    bool isPlaying = true;

    public bool finished = false;


    void Start()
    {
        videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        videoAudio = GetComponent<AudioSource>();
        audioSource.enabled = true;
        if (videoPlayer.clip != null)
        {
            videoPlayer.EnableAudioTrack(0, true);
            videoPlayer.SetTargetAudioSource(0, videoAudio);
        }
    }

    //Check if input keys have been pressed and call methods accordingly.
    public void PlayVideo()
    {
        if (videoPlayer.isPrepared)
        {
            if (isPlaying)
            { audioSource.Play(); }
            videoPlayer.Play();
            videoAudio.Play();
            finished = true;
        }
        else
        {
            Debug.Log("The video is still loading... or audio is still playing");
        }
    }

    public void PauseVideo()
    {
        videoPlayer.Pause();
        if (audioSource.isPlaying) { audioSource.Pause(); isPlaying = true; }
        else { isPlaying = false; }
        videoAudio.Pause();
    }

    public void Restart()
    {
        videoAudio.Play();
        videoPlayer.frame = 0;
        audioSource.Play();
        Button.SetActive(false);
        finished = false;
        isPlaying = true;
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
