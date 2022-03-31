using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject batMan;
    public GameObject bubble;
    public GameObject playerCell;
    public float timeLeft = 60;
    public float enemySpawnTimer;
    private float enemySpawnTimerSave;
    public float bubbleSpawnTimer;
    private float bubbleSpawnTimerSave;
    public float batSpawnTimer;
    private float batSpawnTimerSave;
    public TextMeshProUGUI finalScore;
    private TextMeshProUGUI score;
    public TextMeshProUGUI timer;
    public RectTransform rt;
    public RectTransform rtBubble;
    public Sprite[] enemies;
    public Sprite[] bubbles;

    public GameObject vaccine;

    public Sprite[] red;
    public Sprite[] blue;
    public Image[] lifeBar;
    public Image[] airBar;
    public int life = 6, air =6,lives=3;
    public float secondTimer=3;
    public bool gameOverNow = false;
    public GameObject gameOverScreen;
    public GameObject moveScroll;
    public playerControls controlsFunc;

    public int scoreToReach = 1000;
    private int scoreToReachTemp;

    public GameObject[] live;
    public GameObject invincible;
    public bool invincibleTimer;
    public float invinTimer = 3;

    public GameObject stageNow;

    public bool runAnim = false;
    public float animTimer = 0;
    public int switcher = 0;
    public int counter = 0;
    public int lastAnimTemp = 0;

    public bool vacOnce = false;

    public float gameOverTimer = 0;


    public GameObject[] Canvasfind;
    //public GameObject gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        Canvasfind = GameObject.FindGameObjectsWithTag("canvasGame");
        if (Canvasfind.Length > 1)
        {
            Destroy(Canvasfind[1]);
            Canvasfind[0].SetActive(true);
        }

        score = GameObject.FindGameObjectWithTag("finalScore").GetComponent<TextMeshProUGUI>();
        stageNow = GameObject.FindGameObjectWithTag("stage");
        invinTimer = 3;
        invincibleTimer = false;
        scoreToReachTemp = scoreToReach;
        Debug.Log("Screen Height : " + Screen.height);
        Debug.Log("Screen Width : " + Screen.width);
        enemySpawnTimerSave = enemySpawnTimer;
        bubbleSpawnTimerSave = bubbleSpawnTimer;
        batSpawnTimerSave = batSpawnTimer;

        lifeBar[0].sprite = red[0];
        lifeBar[5].sprite = red[0];
        airBar[0].sprite = blue[5];
        airBar[5].sprite = blue[3];
        for (int i = 1; i < 5; i++)
        {
            lifeBar[i].sprite = red[0];
            airBar[i].sprite = blue[4];
        }

        //secondTimer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOverNow == true)
        {
            gameOverTimer += Time.deltaTime; ;
            if(gameOverTimer >=8) SceneManager.LoadScene("gameOver");
        }
        if(invincibleTimer== true)
        {
            if (invinTimer > 2.75) playerCell.GetComponent<Image>().color = new Color32(255,255,255,1);
            else if(invinTimer > 2.5) playerCell.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            else if (invinTimer > 2.25) playerCell.GetComponent<Image>().color = new Color32(255, 255, 255, 1);
            else if (invinTimer > 2) playerCell.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            else if (invinTimer > 1.75) playerCell.GetComponent<Image>().color = new Color32(255, 255, 255, 1);
            else if (invinTimer > 1.5) playerCell.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            else if (invinTimer > 1.25) playerCell.GetComponent<Image>().color = new Color32(255, 255, 255, 1);
            else if (invinTimer > 1) playerCell.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            else if (invinTimer > 0.75) playerCell.GetComponent<Image>().color = new Color32(255, 255, 255, 1);
            else if (invinTimer > 0.5) playerCell.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            else if (invinTimer > 0.25) playerCell.GetComponent<Image>().color = new Color32(255, 255, 255, 1);
            else if (invinTimer > 0) playerCell.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            invinTimer -= Time.deltaTime;
            if(invinTimer<=0)
            {
                invincible.name = "false";
                invincibleTimer = false;
                invinTimer = 3;
            }
        }
        if(gameOverNow == false)
        {
            score.text = GameObject.FindGameObjectWithTag("score").name;
            secondTimer -= Time.deltaTime;
            if (secondTimer <= 0)
            {
                if (air > 0)
                {
                    if (air == 6) airBar[5].sprite = blue[0];
                    else if (air > 0) airBar[air - 1].sprite = blue[1];
                    air--;
                    if (air <= 0) setLifeCount();
                    secondTimer = 3;
                }
                if (air <= 0) setLifeCount();

            }

            enemySpawnTimer -= Time.deltaTime;
            bubbleSpawnTimer -= Time.deltaTime;
            batSpawnTimer -= Time.deltaTime;

            timeLeft -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(timeLeft / 60F);
            int seconds = Mathf.FloorToInt(timeLeft - minutes * 60);
            timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);



            if (enemySpawnTimer < 0)
            {
                float minEnemyPositionY = Screen.height * 0.75f;
                float maxEnemyPositionY = Screen.height * 0.25f;
                GameObject enemyNow = Instantiate(enemy, new Vector3(Random.Range((0 + (rt.rect.width / 2)), Screen.width - (rt.rect.width / 2)), Random.Range(minEnemyPositionY, maxEnemyPositionY), 0), Quaternion.identity, GameObject.FindGameObjectWithTag("enemyPOS").transform) as GameObject;
                enemyNow.GetComponent<Image>().sprite = enemies[Random.Range(0, 4)];
                enemySpawnTimer = enemySpawnTimerSave;
                Destroy(enemyNow, 10);
            }

            if (batSpawnTimer < 0)
            {
                float minEnemyPositionY = Screen.height * 0.75f;
                float maxEnemyPositionY = Screen.height * 0.25f;
                GameObject batNow = Instantiate(batMan, new Vector3(Screen.width, Random.Range(minEnemyPositionY, maxEnemyPositionY), 0), Quaternion.identity, GameObject.FindGameObjectWithTag("enemyPOS").transform) as GameObject;
                batSpawnTimer = batSpawnTimerSave;
            }

            if (bubbleSpawnTimer < 0)
            {
                float minBubblePositionY = Screen.height * 0.75f;
                float maxBubblePositionY = Screen.height * 0.25f;
                for (int x = 0; x < Random.Range(1, 5); x++)
                {
                    GameObject bubbleNow = Instantiate(bubble, new Vector3(Random.Range((0 + (rt.rect.width / 2)), Screen.width - (rtBubble.rect.width / 2)), Screen.height, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("bubblePOS").transform) as GameObject;
                    bubbleNow.GetComponent<Image>().sprite = bubbles[Random.Range(0, 5)];
                    Destroy(bubbleNow, 10);
                }

                bubbleSpawnTimer = bubbleSpawnTimerSave;
            }
        }



        if(runAnim==true)
        {
            
            animTimer+=  Time.deltaTime;

            if(animTimer>=0.25)
            {
                counter++;
                if (switcher==0)
                {
                    score.color = new Color32(255, 0, 0, 255);
                    switcher = 1;
                }
                else
                {
                    score.color = new Color32(255, 255, 255, 255);
                    switcher = 0;
                }
                animTimer = 0;
            }
            
            if(counter == 10)
            {
                runAnim = false;
                switcher = 0;
                score.color = new Color32(255, 255, 255, 255);
                counter = 0;
            }
        }
   

    }

    public void addAir()
    {
        if(air<6)
        {
            if (air+1 < 6) airBar[air].sprite = blue[4];
            else airBar[air].sprite = blue[3];

            air++;
            secondTimer = 3;
        }
        else secondTimer = 3;
    }

    public void subLife()
    {
        if (life > 0)
        {
            if (life == 6) lifeBar[0].sprite = red[4];
            else if(life==5) lifeBar[1].sprite = red[4];
            else if (life == 4) lifeBar[2].sprite = red[4];
            else if (life == 3) lifeBar[3].sprite = red[4];
            else if (life == 2) lifeBar[4].sprite = red[4];
            else lifeBar[5].sprite = red[0];
            life--;
            if (life <= 0) setLifeCount();
        }
        else gameOver();

        if(life==1 && vacOnce == false)
        {
            GameObject bubbleNow = Instantiate(vaccine, new Vector3(Random.Range((0 + (rt.rect.width / 2)), Screen.width - (rtBubble.rect.width / 2)), Screen.height, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("bubblePOS").transform) as GameObject;
            vacOnce = true;
        }
    }

    public int getLifeCount()
    {
        return lives;
    }

    public void setLifeCount()
    {
        if(invincible.name!="true")
        {
            lives = lives - 1;

            for (int x = 0; x < live.Length; x++) live[x].SetActive(false);
            for (int x = 0; x < lives - 1; x++) live[x].SetActive(true);

            if (lives <= 0) gameOver();
            else
            {
                invincible.name = "true";
                invincibleTimer = true;
                //invinTimer = 3;
            }


            life = 6; air = 6;
            for (int x = 0; x < lifeBar.Length; x++) lifeBar[x].sprite = red[0];
            for (int x = 0; x < airBar.Length; x++) airBar[x].sprite = blue[4];

            vacOnce = false;
        }
    }

    public void startGame()
    {
        life = 6;
        air = 0;
    }

    public int getBubbleInfo()
    {
        return air;
    }

    public void reduceRed()
    {

        life = life + 1;

        if (life == 6) lifeBar[0].sprite = red[0];
        else if (life == 5) lifeBar[1].sprite = red[0];
        else if (life == 4) lifeBar[2].sprite = red[0];
        else if (life == 3) lifeBar[3].sprite = red[0];
        else if (life == 2) lifeBar[4].sprite = red[0];
        else lifeBar[5].sprite = red[0];
    }

    public void gameOver()
    {
        controlsFunc.gameOverOn();
        finalScore.text = GameObject.FindGameObjectWithTag("score").name;
        gameOverNow = true;
        //gameOverScreen.SetActive(true);
        playerCell.SetActive(false);
        moveScroll.SetActive(false);
        //SceneManager.LoadScene("gameOver");
        GameObject.FindGameObjectWithTag("gameOver").name = "GameOver";
    }

    public void resetGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void checkScoring(int a)
    {
        if(lastAnimTemp==0 && a>1000)
        {
            runAnim = true;
            lastAnimTemp = a;
        }
        else if(a-lastAnimTemp>1000)
        {
            runAnim = true;
            lastAnimTemp = a;
        }

       if(a>=scoreToReach)
        {
            lives++;
            for(int x=0;x<live.Length;x++)
            {
                if (x < lives-1) live[x].SetActive(true);
                else live[x].SetActive(false);
            }

            scoreToReach += scoreToReachTemp;
        }

        if (a % 1000 == 0) runAnim = true;
        print("SCORE!:" + a);

       if(a>=10000 && stageNow.name=="Stage1") SceneManager.LoadScene("setStage");
       else if (a >=25000 && stageNow.name == "Stage2") SceneManager.LoadScene("setStage");
    }
}
