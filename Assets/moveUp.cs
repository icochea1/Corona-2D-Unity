using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUp : MonoBehaviour
{
    public float bulletSpeed = 6f;
    public float timeLeft = 0.01f;
    private GameObject game;
    public int bubbleInfo;
    public GameObject explosion;
    public GameObject explosion2;
    public GameObject batExplosion;
    public Vector3 bulletPos;
    public float bulletSpeedCheck;
    public AudioSource hitEnemy;
    public AudioSource hitBubble;
    public GameObject hundred;
    public GameObject stageNow;
    // Start is called before the first frame update
    void Start()
    {
        stageNow = GameObject.FindGameObjectWithTag("stage");
        game = GameObject.FindGameObjectWithTag("MainCamera");
        bulletSpeedCheck = 8;
        hitEnemy = GameObject.FindGameObjectWithTag("soundBulletEnemy").GetComponent<AudioSource>();
        hitBubble = GameObject.FindGameObjectWithTag("soundBulletBubble").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bubbleInfo = game.GetComponent<GameScript>().getBubbleInfo();
        timeLeft -= Time.deltaTime;

        //print("BUBBLE: "+bubbleInfo);
        //print("BUBBLESPEEDCHECK: " + bulletSpeedCheck);

        if (timeLeft <= 0)
        {
            if (Screen.height > 1980) this.transform.Translate(0, (bulletSpeedCheck + (bubbleInfo*2))*2, 0);
            else this.transform.Translate(0, bulletSpeedCheck + (bubbleInfo * 2), 0);

            timeLeft = 0.01f;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Enemy(Clone)")
        {
            bulletPos = new Vector3(collision.gameObject.transform.position.x, this.transform.position.y+30, this.transform.position.z);
            //If the GameObject has the same tag as specified, output this message in the console
            GameObject explodeNow = Instantiate(explosion, bulletPos, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform) as GameObject;
            Destroy(explodeNow, 20);
            hitEnemy.Play();
        }
        else if (collision.gameObject.name == "bb1(Clone)")
        {
            bulletPos = new Vector3(collision.gameObject.transform.position.x, this.transform.position.y + 50, this.transform.position.z);
            GameObject explodeNow3 = Instantiate(batExplosion, bulletPos, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform) as GameObject;
            Destroy(explodeNow3, 20);
            int score = int.Parse(GameObject.FindGameObjectWithTag("score").name);
            score += 100;
            GameObject.FindGameObjectWithTag("score").name = score.ToString();
            hitEnemy.Play();
            game.GetComponent<GameScript>().checkScoring(score);
            GameObject explodeNow4 = Instantiate(hundred, bulletPos, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform) as GameObject;
            Destroy(explodeNow4, 1);
        }
        else if (collision.gameObject.name == "Bubble(Clone)")
        {
            bulletPos = new Vector3(collision.gameObject.transform.position.x, this.transform.position.y+20, this.transform.position.z);
            //If the GameObject has the same tag as specified, output this message in the console
            GameObject explodeNow2 = Instantiate(explosion2, bulletPos, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform) as GameObject;
            Destroy(explodeNow2, 20);

            int score = int.Parse(GameObject.FindGameObjectWithTag("score").name);
            score -= 5;
            GameObject.FindGameObjectWithTag("score").name = score.ToString();
            hitBubble.Play();
        }
        print("HIT!");

        if (collision.gameObject.name != "vaccine(Clone)")
        {
            Destroy(collision.gameObject);
        }

        Destroy(this.gameObject);


    }
}
