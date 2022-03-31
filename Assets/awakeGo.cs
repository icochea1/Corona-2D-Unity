using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class awakeGo : MonoBehaviour
{
    public GameObject goAway;
    public float timeCounter = 0;
    public bool justOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter > 1 && justOnce == false)
        {
            goAway.SetActive(false);
            justOnce = true;
        }
    }
}
