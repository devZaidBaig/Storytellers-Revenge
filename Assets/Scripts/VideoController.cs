using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoController : MonoBehaviour {

    private UnityEngine.Video.VideoPlayer videoPlayer;

    public GameObject Button;
    public AudioSource taj;
    public AudioSource germany;
    public AudioSource iceland;

    public GvrAudioSource GvrTaj;
    public GvrAudioSource GvrGermany;
    public GvrAudioSource GvrIceland;

    public GvrAudioSource audioSource;

    public GameObject EndCredit;
    public GameObject buttonEnd;

    public ParticleSystem rain;
    private AudioSource videoAudio;
    bool isPlaying = true;
    public bool finished = false;


    void Start()
    {
        videoAudio = taj;
        audioSource = GvrTaj;
        videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
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
            { audioSource.Play();
                finished = true;
            }
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
        finished = false;
        videoPlayer.Pause();
        if (audioSource.isPlaying) { audioSource.Pause(); isPlaying = true; }
        else { isPlaying = false; }
        videoAudio.Pause();
    }

    public void Restart()
    {
        videoAudio.Stop();
        videoAudio.Play();
        videoPlayer.frame = 0;
        audioSource.Stop();
        audioSource.Play();
        Button.SetActive(false);
        finished = true;
        isPlaying = true;
    }

    public void ChangeScene(string scene)
    {
        videoAudio.Stop();
        videoPlayer.Stop();
        if (scene == "iceland")
        {
            videoPlayer.url = "https://www.dropbox.com/s/850499ckn7xgbjj/Iceland.mp4?dl=1";
            videoAudio = iceland;
            audioSource = GvrIceland;
            rain.Play();
        }
        else if(scene == "germany")
        {
            videoPlayer.url = "https://www.dropbox.com/s/13d5tggpzqklmsb/travelvideo.mp4?dl=1";
            videoAudio = germany;
            audioSource = GvrGermany;
        }
        if (videoPlayer.isPlaying)
        {
            videoAudio.Play();
            audioSource.Play();
        }

        EndCredit.SetActive(true);
        Button.SetActive(false);
        Button = buttonEnd;
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
