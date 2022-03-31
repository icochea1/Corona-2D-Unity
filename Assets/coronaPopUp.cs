using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coronaPopUp : MonoBehaviour
{
    public GameObject enemy;
    public GameObject BG1;
    public GameObject BG2;
    public GameObject BG22;
    public bool enemyNow = false;
    public float enemySpawnTimer = 0.50f;
    private float enemySpawnTimerSave;
    public float timeleft = 3f;
    public RectTransform rt;
    public Sprite[] enemies;
    public GameObject enterButton;
    
    // Start is called before the first frame update
    void Start()
    {
        enemySpawnTimerSave = enemySpawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyNow == true)
        {
            enemySpawnTimer -= Time.deltaTime;
            timeleft -= Time.deltaTime;

            if (timeleft <= 0)
            {
                enemyNow = false;
                BG1.SetActive(false);
                BG2.SetActive(true);
                BG22.SetActive(true);
            }

            if (enemySpawnTimer < 0 && timeleft>0)
            {
                float minEnemyPositionY = enterButton.transform.position.y - (0.25f * enterButton.transform.position.y);
                float maxEnemyPositionY = enterButton.transform.position.y + (0.25f * enterButton.transform.position.y);
                float minEnemyPositionX = enterButton.transform.position.x - (0.25f* enterButton.transform.position.x);
                float maxEnemyPositionX = enterButton.transform.position.x + (0.25f * enterButton.transform.position.x);
                GameObject enemyNow = Instantiate(enemy, new Vector3(Random.Range(minEnemyPositionX, maxEnemyPositionX), Random.Range(minEnemyPositionY, maxEnemyPositionY), 0), Quaternion.identity, GameObject.FindGameObjectWithTag("enemyPOP").transform) as GameObject;
                enemyNow.GetComponent<Image>().sprite = enemies[Random.Range(0, 1)];
                enemySpawnTimer = enemySpawnTimerSave;
                Destroy(enemyNow, timeleft);
            }
        }
    }

    public void enemySpawn()
    {
        enemyNow = true;
    }
}
