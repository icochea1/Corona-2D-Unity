using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class stageMove : MonoBehaviour
{
    public GameObject stageNow;
    public GameObject CanvasCheck;
    public TextMeshProUGUI stager;
    public float timeLeft = 0;
    public int upDown = 0;
    // Start is called before the first frame update
    void Start()
    {
        CanvasCheck = GameObject.FindGameObjectWithTag("canvasGame");
        stageNow = GameObject.FindGameObjectWithTag("stage");
        if (stageNow.name == "Stage2") stageNow.name = "Stage3";
        else if (stageNow.name == "Stage1") stageNow.name = "Stage2";

        stager.text = stageNow.name;
        CanvasCheck.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
        if (timeLeft < 255 && upDown ==0)
        {
            timeLeft += Time.deltaTime * 150;
            stager.color = new Color32(255, 255, 255, (byte)(timeLeft));
        }
        else if (timeLeft> 254 || upDown==1 && timeLeft>=2)
        {
            upDown = 1;
            timeLeft -= Time.deltaTime * 150;
            stager.color = new Color32(255, 255, 255, (byte)(timeLeft));
        }
        else if(timeLeft<2 && upDown ==1)
        {
            upDown = 0;
        }
    }

    public void goGame()
    {
        CanvasCheck.SetActive(true);
        SceneManager.LoadScene("gameScene");
    }
}
