using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class videoStart : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoPlayer videoPlayer2;
    public float timeLeft = 5;
    public bool timeDone = false;
    public bool timeStart = false;
    public bool prepareNow = false;
    public GameObject vidOld;
    public VideoClip newVideo;
    public GameObject intro, game;
    public float fadeIn = 0;
    public bool startFade = false;
    // Start is called before the first frame update
    void Start()
    {
        //videoPlayer.time = 0; 
        videoPlayer.Pause();
        //videoPlayer2.Stop();

    }

    // Update is called once per frame
    void Update()
    {
        if(timeStart==true)timeLeft -= Time.deltaTime;

        if (timeLeft < 12 && prepareNow == false)
        {
            videoPlayer2.Prepare();
            prepareNow = true;
        }
        if(timeLeft<3) startFade = true;
        if (timeLeft < 1 && timeDone==false && videoPlayer2.isPrepared == true)
        {
            // vidOld.SetActive(false);
            videoPlayer.Stop();
            videoPlayer2.Play();
            videoPlayer2.isLooping = true;

            videoPlayer.clip = newVideo;
            timeDone = true;
            vidOld.SetActive(false);
            //intro.SetActive(true);
            //game.SetActive(true);
                    
        }

        if(startFade==true)
        {
            fadeIn+= Time.deltaTime*50;
            if(fadeIn<=255)
            {
                intro.GetComponent<Image>().color = new Color32(255, 255, 255, (byte)fadeIn);
                game.GetComponent<Image>().color = new Color32(255, 255, 255, (byte)fadeIn);
            }

        }
    }

    public void restart()
    {
        videoPlayer.Play();
        videoPlayer.time = 0;
    }

    public void timeStarter()
    {
        timeStart = true;
    }
}
