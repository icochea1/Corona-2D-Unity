using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreNow : MonoBehaviour
{
    public TextMeshProUGUI scoreChanger;
    // Start is called before the first frame update
    void Start()
    {
        GameObject fS = GameObject.FindGameObjectWithTag("finalScore");//finalScore.text = GameObject.FindGameObjectWithTag("score").name;
        scoreChanger.text = fS.GetComponent<TextMeshProUGUI>().text + " pts";
        GameObject.FindGameObjectWithTag("canvasGame").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goIntro()
    {
        SceneManager.LoadScene("videoLoop");
    }
}
