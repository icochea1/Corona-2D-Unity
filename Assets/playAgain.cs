using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playAgain : MonoBehaviour
{
    public Image playButton;
    public float timeLeft = 0;
    public int switcher = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft += Time.deltaTime;
        if (timeLeft > 0.4)
        {
            if(switcher == 0)
            {
                playButton.GetComponent<Image>().color = new Color32(255, 255, 255, 1);
                switcher = 1;
            }
            else if (switcher == 1)
            {
                playButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                switcher = 0;
            }

            timeLeft = 0;
        }
    }

    public void playNow()
    {
        SceneManager.LoadScene("gameScene");
    }
}
