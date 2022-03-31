using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeInGameOver : MonoBehaviour
{
    public Image b1,b2,b3,b4;
    public float fadeNum = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fadeNum += Time.deltaTime * 40;
        if (fadeNum < 255)
        {
            b1.color = new Color32(255, 255, 255, (byte)(fadeNum));
            b2.color = new Color32(255, 255, 255, (byte)(fadeNum));
            b3.color = new Color32(255, 255, 255, (byte)(fadeNum));
            b4.color = new Color32(255, 255, 255, (byte)(fadeNum));
        }
    }
}
