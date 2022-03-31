using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemyDown : MonoBehaviour
{
    private float enemySpeed;
    public float timeLeft = 0.01f;
    private GameObject game;
    private GameObject[] status;
    private GameObject scoreStatus;
    public int score = 0;
    public GameObject explosion;
    public GameObject explosionPlayer;
    private AudioSource hitPlayer;
    private AudioSource hitFloor;
    public GameObject stageNow;
    public int multiplier;
    // Start is called before the first frame update
    void Start()
    {
        scoreStatus = GameObject.FindGameObjectWithTag("score");
        stageNow = GameObject.FindGameObjectWithTag("stage");
        enemySpeed = Random.Range(0.5f, 1.5f);
        game = GameObject.FindGameObjectWithTag("MainCamera");

        hitPlayer = GameObject.FindGameObjectWithTag("soundEnemyPlayer").GetComponent<AudioSource>();
        hitFloor = GameObject.FindGameObjectWithTag("soundBulletBubble").GetComponent<AudioSource>();

        if (stageNow.name == "Stage2") multiplier = 2;
        else if (stageNow.name == "Stage3") multiplier = 3;
        else multiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {

            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                if (Screen.height > 1980) this.transform.Translate(0, (-1 * enemySpeed* multiplier) *2, 0);
                else this.transform.Translate(0, -1 * enemySpeed* multiplier, 0);


            if (stageNow.name == "Stage2") timeLeft = 0.008f;
            else if (stageNow.name == "Stage3") timeLeft = 0.005f;
            else timeLeft = 0.01f;


        }
            //print("START!");
  
    }

    void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.name == "Player")
        {
            Vector3 bulletPos = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);
            GameObject explodeNow = Instantiate(explosionPlayer, bulletPos, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform) as GameObject;
            Destroy(explodeNow, 20);

            hitPlayer.Play();
            Destroy(this.gameObject);
            int liveCount = game.GetComponent<GameScript>().getLifeCount();
            liveCount--;

            print(liveCount);
            game.GetComponent<GameScript>().setLifeCount();
        }
        else if(collision.gameObject.name == "Floor2")
        {
            hitFloor.Play();
            game.GetComponent<GameScript>().subLife();
        }
        else if (collision.gameObject.name == "bullet(Clone)")
        {
            Destroy(this.gameObject);
            score = int.Parse(scoreStatus.name);
            score+=25;
            scoreStatus.name = score.ToString();
            game.GetComponent<GameScript>().checkScoring(score);
        }

    }

}
