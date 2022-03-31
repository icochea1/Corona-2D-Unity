using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerControls : MonoBehaviour
{
    public RectTransform rt;
    public GameObject bullet;
    public Sprite[] playerImage;
    public bool gameOverNow = false;
    public AudioSource bulletSound;
    public GameObject live2, live3, live4, live5, live6, live7, live8, live9;
    // Start is called before the first frame update
    void Start()
    {
       // rt.rect.width = Screen.weight / 10;
       // rt.rect.height = Screen.height / 10;
        if(Screen.height < 1900)rt.sizeDelta = new Vector2(Screen.width / 10, Screen.width / 10);
        else rt.sizeDelta = new Vector2(Screen.width / 20, Screen.width / 20);
        Debug.Log("Player Width : " + rt.rect.width);
        this.transform.position = new Vector3(Screen.width * 0.5f, (Screen.height * 0.5f)- (Screen.height * 0.5f)+(rt.rect.height), 0);
        int playerImageChooser = Random.Range(0, 5);
        this.GetComponent<Image>().sprite = playerImage[playerImageChooser];
        live2.GetComponent<Image>().sprite = playerImage[playerImageChooser];
        live3.GetComponent<Image>().sprite = playerImage[playerImageChooser];
        live4.GetComponent<Image>().sprite = playerImage[playerImageChooser];
        live5.GetComponent<Image>().sprite = playerImage[playerImageChooser];
        live6.GetComponent<Image>().sprite = playerImage[playerImageChooser];
        live7.GetComponent<Image>().sprite = playerImage[playerImageChooser];
        live8.GetComponent<Image>().sprite = playerImage[playerImageChooser];
        live9.GetComponent<Image>().sprite = playerImage[playerImageChooser];

        live2.transform.position = new Vector3(Screen.width * 0.2f, Screen.height, 0);
        live3.transform.position = new Vector3(Screen.width * 0.3f, Screen.height, 0);
        live4.transform.position = new Vector3(Screen.width * 0.4f, Screen.height, 0);
        live5.transform.position = new Vector3(Screen.width * 0.5f, Screen.height, 0);
        live6.transform.position = new Vector3(Screen.width * 0.6f, Screen.height, 0);
        live7.transform.position = new Vector3(Screen.width * 0.7f, Screen.height, 0);
        live8.transform.position = new Vector3(Screen.width * 0.8f, Screen.height, 0);
        live9.transform.position = new Vector3(Screen.width * 0.9f, Screen.height, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //print(this.transform.position.x);
        float actualPosition = this.transform.position.x + (rt.rect.width/2);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if(actualPosition<= Screen.width) this.transform.Translate(5, 0, 0);
            //Debug.Log("Right Arrow was pressed.");
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (actualPosition- rt.rect.width >= 0) this.transform.Translate(-5, 0, 0);
            //Debug.Log("Left Arrow was pressed.");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
           // GameObject enemy = GameObject.Instantiate(bullet, Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            GameObject bulletNow = Instantiate(bullet, new Vector3(this.transform.position.x, this.transform.position.y+(rt.rect.width/2), this.transform.position.z), Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform) as GameObject;
            Destroy(bulletNow, 5);
        }
    }

    public void Shoot()
    {
        if(gameOverNow==false)
        {
            bulletSound.Play();
            GameObject bulletNow = Instantiate(bullet, new Vector3(this.transform.position.x, this.transform.position.y + (rt.rect.width / 2), this.transform.position.z), Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform) as GameObject;
            Destroy(bulletNow, 5);
        }

    }

    public void gameOverOn()
    {
        gameOverNow = true;
    }
}
