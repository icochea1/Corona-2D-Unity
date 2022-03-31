using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goIntro : MonoBehaviour
{
    public RectTransform intoRect;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Screen Width : " + Screen.width);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playIntro()
    {
        SceneManager.LoadScene("intro");
    }
}
