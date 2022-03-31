using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class startVideoGone : MonoBehaviour
{
    public float timeLeft = 5;
    public VideoPlayer videoPlayer;
    public VideoPlayer videoPlayer2;
    public GameObject p1;
    public GameObject v1;
    public GameObject v2;
    public bool itsDone = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0 && itsDone == false)
        {
            videoPlayer.Stop();
            p1.SetActive(true);
            v1.SetActive(false);
            v2.SetActive(true);
            itsDone = true;
            videoPlayer2.time = 0;
            videoPlayer2.Pause();
            
        }
    }

}
