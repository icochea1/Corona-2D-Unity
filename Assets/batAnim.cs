using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class batAnim : MonoBehaviour
{
    public Sprite[] superBat;
    public float timeLeft = 0;
    public float timeLeft2 = 0;
    public int frameCounter = 0;
    public Image batman;
    public GameObject batMove;
    public GameObject stageNow;
    // Start is called before the first frame update
    void Start()
    {
        stageNow = GameObject.FindGameObjectWithTag("stage");
        batman.sprite = superBat[frameCounter];


    }

    // Update is called once per frame
    void Update()
    {
        timeLeft+= Time.deltaTime;
        timeLeft2+= Time.deltaTime;
        if (timeLeft>0.1)
        {
           
            frameCounter++;
            batman.sprite = superBat[frameCounter];

            if (frameCounter > 8) frameCounter = 0;
            timeLeft = 0;
        }

        if(timeLeft2>0.01)
        {
            if (stageNow.name == "Stage2") this.transform.Translate(-1f, 0f, 0f);
            else if (stageNow.name == "Stage3") this.transform.Translate(-1.2f, 0f, 0f);
                    else this.transform.Translate(-0.8f, 0f, 0f);

            timeLeft2 = 0;
        }

        if (this.transform.position.x < -50) Destroy(batMove);



        //if(this.transform.positio)Screen.width

    }

}
