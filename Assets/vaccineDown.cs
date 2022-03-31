using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vaccineDown : MonoBehaviour
{
    private float vaccineSpeed = 1f;
    public float timeLeft = 0.01f;
    private AudioSource hitPlayer;
    private GameObject game;
    public GameObject thisVaccine;
    public GameObject explosionGood;
    public Vector3 bubblePosition;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.FindGameObjectWithTag("MainCamera");
        hitPlayer = GameObject.FindGameObjectWithTag("soundEnemyPlayer").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            if (Screen.height > 1980) this.transform.Translate(0, (-1 * vaccineSpeed) * 2, 0);
            else this.transform.Translate(0, -1 * vaccineSpeed, 0);
            timeLeft = 0.01f;
        }

        bubblePosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.name == "Player")
        {
            GameObject explodeNow2 = Instantiate(explosionGood, bubblePosition, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform) as GameObject;
            Destroy(explodeNow2, 20);
            print("HIT PLAYER VACCINE!");

            hitPlayer.Play();
            Destroy(this.gameObject);
            game.GetComponent<GameScript>().reduceRed();
        }
        else if (collision.gameObject.name == "Floor2")
        {
            Destroy(thisVaccine);
        }
    }
}
