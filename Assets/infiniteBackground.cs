using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infiniteBackground : MonoBehaviour
{
    public GameObject[] backgrounds;
    public float timeLeft = 0.01f;
    private float speed;
    public float x, y, z;

    public RectTransform[] rt;
    public GameObject[] RectBGs;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1f;
        x = RectBGs[0].transform.position.x;
        y = RectBGs[0].transform.position.y;
        z = RectBGs[0].transform.position.z;

        Debug.Log("Screen Height : " + Screen.height);
        Debug.Log("Screen Width : " + Screen.width);
        rt[0].sizeDelta = new Vector2(Screen.width, Screen.height);
        rt[1].sizeDelta = new Vector2(Screen.width, Screen.height);
        rt[2].sizeDelta = new Vector2(Screen.width, Screen.height);

        RectBGs[1].transform.position = new Vector3(x,y+ Screen.height, z);
        RectBGs[2].transform.position = new Vector3(x, y + (Screen.height*2), z);

    }

    // Update is called once per frame
    void Update()
    {
        print(RectBGs[2].transform.position.y);
        //if (this.transform.position.y <= -1880) this.transform.position = new Vector3(x, y, z);
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            RectBGs[0].transform.Translate(0, -1 * speed, 0);
            RectBGs[1].transform.Translate(0, -1 * speed, 0);
            RectBGs[2].transform.Translate(0, -1 * speed, 0);
            timeLeft = 0.01f;
        }
    }
}

//Its starting from Screensize * 3 - (Screensize/2)

    // It reaches 1920 Which is Half of screensize*3
