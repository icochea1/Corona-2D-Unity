using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    public RectTransform intoRect;
    // Start is called before the first frame update
    void Start()
    {
        if (Screen.height < 1000)
        {
            //this.transform.Translate(0, 300, 0);
        }
        else if (Screen.height < 1300)
        {
           // this.transform.Translate(0, 250, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goGame()
    {
        SceneManager.LoadScene("gameScene");
    }
}
