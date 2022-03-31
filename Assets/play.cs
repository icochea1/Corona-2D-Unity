using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class play : MonoBehaviour
{
    public GameObject pButton;
    public float timeLeft = 0;
    public VideoPlayer video;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft += Time.deltaTime;
        if (timeLeft>3)timeLeft += Time.deltaTime * 40;
        if (timeLeft < 255) pButton.GetComponent<Image>().color = new Color32(255, 255, 255, (byte)timeLeft);

        print(video.time);

        if(video.time>=92) SceneManager.LoadScene("videoLoop");
    }

    public void playGame()
    {
        SceneManager.LoadScene("gameScene");
    }
}
