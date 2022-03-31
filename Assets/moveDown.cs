using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveDown : MonoBehaviour
{
    private float bubbleSpeed;
    public float timeLeft = 0.01f;
    private GameObject game;
    public GameObject explosion2;
    public GameObject explosionGood;
    public Vector3 bubblePosition;
    public AudioSource hitEnemy;
    public AudioSource hitPlayer;
    public GameObject stageNow;
    public int multiplier;
    // Start is called before the first frame update
    void Start()
    {
        bubbleSpeed = Random.Range(3f,8f);
        game = GameObject.FindGameObjectWithTag("MainCamera");

        stageNow = GameObject.FindGameObjectWithTag("stage");
        hitEnemy = GameObject.FindGameObjectWithTag("soundBubbleEnemy").GetComponent<AudioSource>();
        hitPlayer = GameObject.FindGameObjectWithTag("soundPlayerBubble").GetComponent<AudioSource>();

        if (stageNow.name == "Stage2") multiplier = 2;
        else if (stageNow.name == "Stage3") multiplier = 3;
        else multiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft<=0)
        {
            if(Screen.height>1980) this.transform.Translate(0, -1 * bubbleSpeed*2/ multiplier, 0);
            else this.transform.Translate(0, -1 * bubbleSpeed / multiplier, 0);
            if(stageNow.name=="Stage1")timeLeft = 0.01f;
            else if (stageNow.name == "Stage2") timeLeft = 0.03f;
            else if (stageNow.name == "Stage3") timeLeft = 0.05f;

        }
        bubblePosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
       // print(collision.gameObject.name);

        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Enemy(Clone)" )
        {
            hitEnemy.Play();
            GameObject explodeNow2 = Instantiate(explosion2, bubblePosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform) as GameObject;
            Destroy(explodeNow2, 20);
            //If the GameObject's name matches the one you suggest, output this message in the console
            print("HIT!");
           // Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

        else if (collision.gameObject.name == "Player")
        {
            hitPlayer.Play();
            GameObject powerUp = Instantiate(explosionGood, bubblePosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform) as GameObject;
            Destroy(powerUp, 20);
            //If the GameObject's name matches the one you suggest, output this message in the console
            print("HIT!");
            // Destroy(collision.gameObject);
            Destroy(this.gameObject);
            game.GetComponent<GameScript>().addAir();

        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "MyGameObjectTag")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Do something else here");
        }
    }

    /*void OnTriggerExit2D(Collider2D collision)
    {
        // print(collision.gameObject.name);

        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Enemy(Clone)")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            print("HIT!");
            // Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "MyGameObjectTag")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Do something else here");
        }
    }*/

}
