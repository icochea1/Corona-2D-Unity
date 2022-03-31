using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class intoPlay : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.time = 1.5;
        videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(videoPlayer.time>92) SceneManager.LoadScene("videoLoop");
    }
}
