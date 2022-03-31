using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class fadeIn : MonoBehaviour
{
    public Image enter;
    public float fadeNum=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fadeNum += Time.deltaTime * 40;
        if(fadeNum<255)enter.color = new Color32(255, 255, 255, (byte)(fadeNum));
    }
}
